using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MPropSandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] files = Directory.GetFiles(@"M:\My Documents\GitHub\mpropsandbox\Data", "*.csv");

            List<MpropField> mpropFields = new List<MpropField>();

            StringBuilder sb = new StringBuilder();
            List<string> conflicts = new List<string>();

            foreach (PropertyInfo propertyInfo in typeof(Property).GetProperties())
            {
                mpropFields.Add(new MpropField()
                {
                    DataModelName = propertyInfo.Name,
                    DataFileNames = new List<string>()
                    {
                        propertyInfo.Name
                    }
                });
            }

            foreach (string file in files)
            {
                string fileYearShort = file.Substring(file.LastIndexOf("\\") + 1);
                fileYearShort = fileYearShort.Replace(".csv", "");

                if (fileYearShort.ToLower().StartsWith("mprop") && fileYearShort.Length == 7)
                    fileYearShort = fileYearShort.Substring(5);
                else if (fileYearShort.ToLower().StartsWith("mprop") && fileYearShort.Length == 12)
                    fileYearShort = fileYearShort.Substring(7, 2);

                int fileYear = int.Parse(fileYearShort);
                if (fileYear < 50)
                    fileYear += 2000;
                else
                    fileYear += 1900;

                using (var streamReader = new StreamReader(file))
                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    csvReader.Read();
                    csvReader.ReadHeader();
                    foreach (string field in csvReader.Context.HeaderRecord)
                    {
                        MpropField mpropField = mpropFields.SingleOrDefault(x => x.DataFileNames.Any(x => x == field));

                        if (mpropField == null)
                            mpropField = mpropFields.FirstOrDefault(x => x.DataFileNames.Any(x => x.Replace("_", "") == field));

                        if (mpropField == null)
                            mpropField = mpropFields.FirstOrDefault(x => x.DataFileNames.Any(x => x.Replace("_", "").StartsWith(field)));

                        if (mpropField == null)
                            mpropField = mpropFields.FirstOrDefault(x => x.DataFileNames.Any(x => x.StartsWith(field)));

                        if (mpropField == null)
                            mpropField = mpropFields.FirstOrDefault(x => x.DataModelName == GetKnownAlias(field));

                        if (mpropField == null)
                        {
                            mpropField = new MpropField()
                            {
                                DataFileNames = new List<string>()
                                {
                                    field
                                }
                            };
                            mpropFields.Add(mpropField);
                        }

                        if (!mpropField.DataFileNames.Contains(field))
                            mpropField.DataFileNames.Add(field);

                        if (mpropField.Years.Contains(fileYear))
                            conflicts.Add(fileYear + " exists multiple times for field " + field);
                        else
                            mpropField.Years.Add(fileYear);
                    }
                }
            }

            sb.AppendLine(mpropFields.Count + " fields");
            sb.AppendLine(string.Join("\r\n", conflicts));

            foreach (MpropField mpropField in mpropFields.Where(x => !string.IsNullOrEmpty(x.DataModelName)).OrderBy(x => x.DataModelName))
            {
                sb.Append("(" + mpropField.Years.Count + ") " + mpropField.DataModelName + ": ");
                sb.AppendLine(string.Join(",", mpropField.DataFileNames.Select(x => x.ToString())));
                sb.AppendLine(string.Join(",", mpropField.Years.OrderBy(x => x).Select(x => x.ToString())));
            }

            foreach (MpropField mpropField in mpropFields.Where(x => string.IsNullOrEmpty(x.DataModelName)).OrderBy(x => x.DataFileNames[0]))
            {
                sb.Append("(" + mpropField.Years.Count + ") ");
                sb.AppendLine(string.Join(",", mpropField.DataFileNames.Select(x => x.ToString())));
                sb.AppendLine(string.Join(",", mpropField.Years.OrderBy(x => x).Select(x => x.ToString())));
            }

            File.WriteAllText("output.txt", sb.ToString());

            Console.Write(sb.ToString());
        }

        static string GetKnownAlias(string alias)
        {
            switch (alias)
            {
                case "BATHROOM": return "BATHS";

                case "BUILDTYP": return "BLDG_TYPE";

                case "CHECKDIG": return "CHK_DIGIT";
                case "CHNGNUM": return "CHG_NR";

                case "CONVDATE": return "CONVEY_DATE";
                case "CONVFEE": return "CONVEY_FEE";
                case "CONVTYPE": return "CONVEY_TYPE";

                case "CUREXIMP": return "C_A_EXM_IMPRV";
                case "CUREXLND": return "C_A_EXM_LAND";
                case "CUREXTOT": return "C_A_EXM_TOTAL";
                case "CUREXTYP": return "C_A_EXM_TYPE";

                case "CURIMPAS": return "C_A_IMPRV";
                case "CURLNDAS": return "C_A_LAND";
                case "CURSYMBL": return "C_A_SYMBOL";
                case "CURTOTAS": return "C_A_TOTAL";
                case "CURCLSCD": return "C_A_CLASS";

                case "EXMPACRG": return "EXM_ACREAGE";
                case "EXMPIMPR": return "EXM_PER_CT_IMPRV";
                case "EXMPLAND": return "EXM_PER_CT_LAND";

                case "GARAGETP":
                case "GARAGE_TYPE":
                    return "PARKING_TYPE";

                case "ALDERDIS": return "GEO_ALDER";
                case "ALDEROLD": return "GEO_ALDER_OLD";
                case "BIMNTDIS": return "GEO_BI_MAINT";
                case "CENBLOCK": return "GEO_BLOCK";
                case "CENTRACT": return "GEO_TRACT";
                case "FIREDIST": return "GEO_FIRE";
                case "POLICEDS": return "GEO_POLICE";

                case "HISTDES": return "HIST_CODE";

                case "HSNUMHI": return "HOUSE_NR_HI";
                case "HSNUMLO": return "HOUSE_NR_LO";
                case "HSNUMSUF": return "HOUSE_NR_SFX";

                case "NAMCHDAT": return "LAST_NAME_CHG";

                case "NUMUNITS": return "NR_UNITS";
                case "NSTORIES": return "NR_STORIES";
                case "NOFSPACES":
                case "NUMBER_OF_SPACES":
                    return "PARKING_SPACES";
                case "NEIGHBORHD":
                case "NBRHOOD":
                    return "NEIGHBORHOOD";
                
                case "OWNER_NA_1":
                case "OWNRNAM1": 
                    return "OWNER_NAME_1";
                case "OWNER_NA_2":
                case "OWNRNAM2":
                    return "OWNER_NAME_2";
                case "OWNER_NA_3":
                case "OWNRNAM3":
                    return "OWNER_NAME_3";
                case "OWNRADDR":
                case "OWNERADDR":
                    return "OWNER_MAIL_ADDR";
                case "OWNRCITY": return "OWNER_CITY_STATE";
                case "OWNRZIP": return "OWNER_ZIP";
                case "OWNEROCC": return "OWN_OCPD";

                case "PREEXIMP": return "P_A_EXM_IMPRV";
                case "PREEXLND": return "P_A_EXM_LAND";
                case "PREEXTOT": return "P_A_EXM_TOTAL";
                case "PREEXMTP": return "P_A_EXM_TYPE";

                case "PREIMPAS": return "P_A_IMPRV";
                case "PRELNDAS": return "P_A_LAND";
                case "PRESYMBL": return "P_A_SYMBOL";
                case "PRETOTAS": return "P_A_TOTAL";
                case "PRECLSCD": return "P_A_CLASS";

                case "PWDRROOM": return "POWDER_ROOMS";

                case "REASFCHG": return "REASON_FOR_CHG";

                case "SANIDIST": return "DPW_SANITATION";

                case "STRTDIR":
                case "DIR":
                    return "SDIR";
                case "STRTNAME": return "STREET";
                case "STRTTYPE": return "STTYPE";

                case "TOTROOMS": return "NR_ROOMS";

                case "YEARASS": return "YR_ASSMT";
            }

            return alias;
        }

        static void ShowFieldsByYear()
        {
            string[] files = Directory.GetFiles(@"M:\Downloads\mprop-historical", "*.csv");

            Dictionary<string, List<int>> allFields = new Dictionary<string, List<int>>();

            foreach (string file in files)
            {
                string fileYearShort = file.Substring(file.LastIndexOf("\\") + 1);
                fileYearShort = fileYearShort.Replace(".csv", "");

                if (fileYearShort.ToLower().StartsWith("mprop") && fileYearShort.Length == 7)
                    fileYearShort = fileYearShort.Substring(5);
                else if (fileYearShort.ToLower().StartsWith("mprop") && fileYearShort.Length == 12)
                    fileYearShort = fileYearShort.Substring(7, 2);

                int fileYear = int.Parse(fileYearShort);
                if (fileYear < 50)
                    fileYear += 2000;
                else
                    fileYear += 1900;

                using (var streamReader = new StreamReader(file))
                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    csvReader.Read();
                    csvReader.ReadHeader();
                    foreach (string field in csvReader.Context.HeaderRecord)
                    {
                        if (!allFields.ContainsKey(field))
                            allFields.Add(field, new List<int>());

                        allFields[field].Add(fileYear);
                    }
                }
            }

            foreach (string field in allFields.Keys)
                allFields[field].Sort();

            foreach (string field in allFields.Keys.OrderBy(x => x))
            {
                Console.WriteLine(field);
                Console.WriteLine(string.Join(",", allFields[field].Select(x => x.ToString())));
            }

            Console.ReadLine();
        }
    }
}
