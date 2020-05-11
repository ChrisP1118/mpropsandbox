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
			GenerateMpropFields();
			//ReadSample();
        }

		static void ReadSample()
		{
			List<MpropField> mpropFields = new List<MpropField>()
			{
				new MpropField
				{
					DataModelName = "AIR_CONDITIONING",
					PropertyInfo = typeof(Property).GetProperty("AIR_CONDITIONING"),
					DataFileNames = new List<string>()
					{
						"AIR_CONDITIONING",
						"AIRCONDIT",
						"AIR_CONDIT",
						"AIRCOND",
					}
				},
				new MpropField
				{
					DataModelName = "ANGLE",
					PropertyInfo = typeof(Property).GetProperty("ANGLE"),
					DataFileNames = new List<string>()
					{
						"ANGLE",
					}
				},
				new MpropField
				{
					DataModelName = "ATTIC",
					PropertyInfo = typeof(Property).GetProperty("ATTIC"),
					DataFileNames = new List<string>()
					{
						"ATTIC",
					}
				},
				new MpropField
				{
					DataModelName = "BASEMENT",
					PropertyInfo = typeof(Property).GetProperty("BASEMENT"),
					DataFileNames = new List<string>()
					{
						"BASEMENT",
					}
				},
				new MpropField
				{
					DataModelName = "BATHS",
					PropertyInfo = typeof(Property).GetProperty("BATHS"),
					DataFileNames = new List<string>()
					{
						"BATHS",
						"BATHROOM",
					}
				},
				new MpropField
				{
					DataModelName = "BEDROOMS",
					PropertyInfo = typeof(Property).GetProperty("BEDROOMS"),
					DataFileNames = new List<string>()
					{
						"BEDROOMS",
					}
				},
				new MpropField
				{
					DataModelName = "BI_VIOL",
					PropertyInfo = typeof(Property).GetProperty("BI_VIOL"),
					DataFileNames = new List<string>()
					{
						"BI_VIOL",
						"BIVIOL",
					}
				},
				new MpropField
				{
					DataModelName = "BLDG_AREA",
					PropertyInfo = typeof(Property).GetProperty("BLDG_AREA"),
					DataFileNames = new List<string>()
					{
						"BLDG_AREA",
						"BLDGAREA",
					}
				},
				new MpropField
				{
					DataModelName = "BLDG_TYPE",
					PropertyInfo = typeof(Property).GetProperty("BLDG_TYPE"),
					DataFileNames = new List<string>()
					{
						"BLDG_TYPE",
						"BLDGTYPE",
						"BUILDTYP",
					}
				},
				new MpropField
				{
					DataModelName = "C_A_CLASS",
					PropertyInfo = typeof(Property).GetProperty("C_A_CLASS"),
					DataFileNames = new List<string>()
					{
						"C_A_CLASS",
						"CACLASS",
						"CURCLSCD",
					}
				},
				new MpropField
				{
					DataModelName = "C_A_EXM_IMPRV",
					PropertyInfo = typeof(Property).GetProperty("C_A_EXM_IMPRV"),
					DataFileNames = new List<string>()
					{
						"C_A_EXM_IMPRV",
						"CAEXMIMPRV",
						"C_A_EXM_IM",
						"CUREXIMP",
					}
				},
				new MpropField
				{
					DataModelName = "C_A_EXM_LAND",
					PropertyInfo = typeof(Property).GetProperty("C_A_EXM_LAND"),
					DataFileNames = new List<string>()
					{
						"C_A_EXM_LAND",
						"CAEXMLAND",
						"C_A_EXM_LA",
						"CUREXLND",
					}
				},
				new MpropField
				{
					DataModelName = "C_A_EXM_TOTAL",
					PropertyInfo = typeof(Property).GetProperty("C_A_EXM_TOTAL"),
					DataFileNames = new List<string>()
					{
						"C_A_EXM_TOTAL",
						"CAEXMTOTAL",
						"C_A_EXM_TO",
						"CUREXTOT",
					}
				},
				new MpropField
				{
					DataModelName = "C_A_EXM_TYPE",
					PropertyInfo = typeof(Property).GetProperty("C_A_EXM_TYPE"),
					DataFileNames = new List<string>()
					{
						"C_A_EXM_TYPE",
						"CAEXMTYPE",
						"C_A_EXM_TY",
						"CUREXTYP",
					}
				},
				new MpropField
				{
					DataModelName = "C_A_IMPRV",
					PropertyInfo = typeof(Property).GetProperty("C_A_IMPRV"),
					DataFileNames = new List<string>()
					{
						"C_A_IMPRV",
						"CAIMPRV",
						"CURIMPAS",
					}
				},
				new MpropField
				{
					DataModelName = "C_A_LAND",
					PropertyInfo = typeof(Property).GetProperty("C_A_LAND"),
					DataFileNames = new List<string>()
					{
						"C_A_LAND",
						"CALAND",
						"CURLNDAS",
					}
				},
				new MpropField
				{
					DataModelName = "C_A_SYMBOL",
					PropertyInfo = typeof(Property).GetProperty("C_A_SYMBOL"),
					DataFileNames = new List<string>()
					{
						"C_A_SYMBOL",
						"CASYMBOL",
						"CURSYMBL",
					}
				},
				new MpropField
				{
					DataModelName = "C_A_TOTAL",
					PropertyInfo = typeof(Property).GetProperty("C_A_TOTAL"),
					DataFileNames = new List<string>()
					{
						"C_A_TOTAL",
						"CATOTAL",
						"CURTOTAS",
					}
				},
				new MpropField
				{
					DataModelName = "CHG_NR",
					PropertyInfo = typeof(Property).GetProperty("CHG_NR"),
					DataFileNames = new List<string>()
					{
						"CHG_NR",
						"CHGNR",
						"CHNGNUM",
					}
				},
				new MpropField
				{
					DataModelName = "CHK_DIGIT",
					PropertyInfo = typeof(Property).GetProperty("CHK_DIGIT"),
					DataFileNames = new List<string>()
					{
						"CHK_DIGIT",
						"CHKDIGIT",
						"CHECKDIG",
					}
				},
				new MpropField
				{
					DataModelName = "CONVEY_DATE",
					PropertyInfo = typeof(Property).GetProperty("CONVEY_DATE"),
					DataFileNames = new List<string>()
					{
						"CONVEY_DATE",
						"CONVEYDATE",
						"CONVEY_DAT",
						"CONVDATE",
					}
				},
				new MpropField
				{
					DataModelName = "CONVEY_FEE",
					PropertyInfo = typeof(Property).GetProperty("CONVEY_FEE"),
					DataFileNames = new List<string>()
					{
						"CONVEY_FEE",
						"CONVEYFEE",
						"CONVFEE",
					}
				},
				new MpropField
				{
					DataModelName = "CONVEY_TYPE",
					PropertyInfo = typeof(Property).GetProperty("CONVEY_TYPE"),
					DataFileNames = new List<string>()
					{
						"CONVEY_TYPE",
						"CONVEYTYPE",
						"CONVEY_TYP",
						"CONVTYPE",
					}
				},
				new MpropField
				{
					DataModelName = "CORNER_LOT",
					PropertyInfo = typeof(Property).GetProperty("CORNER_LOT"),
					DataFileNames = new List<string>()
					{
						"CORNER_LOT",
						"CORNER",
					}
				},
				new MpropField
				{
					DataModelName = "DIV_DROP",
					PropertyInfo = typeof(Property).GetProperty("DIV_DROP"),
					DataFileNames = new List<string>()
					{
						"DIV_DROP",
						"DIVDROP",
					}
				},
				new MpropField
				{
					DataModelName = "DIV_ORG",
					PropertyInfo = typeof(Property).GetProperty("DIV_ORG"),
					DataFileNames = new List<string>()
					{
						"DIV_ORG",
						"DIVORG",
					}
				},
				new MpropField
				{
					DataModelName = "DPW_SANITATION",
					PropertyInfo = typeof(Property).GetProperty("DPW_SANITATION"),
					DataFileNames = new List<string>()
					{
						"DPW_SANITATION",
						"DPWSANITAT",
						"DPW_SANITA",
						"SANIDIST",
					}
				},
				new MpropField
				{
					DataModelName = "EXM_ACREAGE",
					PropertyInfo = typeof(Property).GetProperty("EXM_ACREAGE"),
					DataFileNames = new List<string>()
					{
						"EXM_ACREAGE",
						"EXMACREAGE",
						"EXM_ACREAG",
						"EXMPACRG",
					}
				},
				new MpropField
				{
					DataModelName = "EXM_PER_CT_IMPRV",
					PropertyInfo = typeof(Property).GetProperty("EXM_PER_CT_IMPRV"),
					DataFileNames = new List<string>()
					{
						"EXM_PER_CT_IMPRV",
						"EXM_PER_CT",
						"EXMPIMPR",
					}
				},
				new MpropField
				{
					DataModelName = "EXM_PER_CT_LAND",
					PropertyInfo = typeof(Property).GetProperty("EXM_PER_CT_LAND"),
					DataFileNames = new List<string>()
					{
						"EXM_PER_CT_LAND",
						"EXMPLAND",
					}
				},
				new MpropField
				{
					DataModelName = "FIREPLACE",
					PropertyInfo = typeof(Property).GetProperty("FIREPLACE"),
					DataFileNames = new List<string>()
					{
						"FIREPLACE",
						"FIREPLAC",
					}
				},
				new MpropField
				{
					DataModelName = "GARAGE_TYPE",
					PropertyInfo = typeof(Property).GetProperty("GARAGE_TYPE"),
					DataFileNames = new List<string>()
					{
						"GARAGE_TYPE",
						"GARAGETYPE",
						"GARAGE",
					}
				},
				new MpropField
				{
					DataModelName = "GEO_ALDER",
					PropertyInfo = typeof(Property).GetProperty("GEO_ALDER"),
					DataFileNames = new List<string>()
					{
						"GEO_ALDER",
						"GEOALDER",
						"ALDERDIS",
					}
				},
				new MpropField
				{
					DataModelName = "GEO_ALDER_OLD",
					PropertyInfo = typeof(Property).GetProperty("GEO_ALDER_OLD"),
					DataFileNames = new List<string>()
					{
						"GEO_ALDER_OLD",
						"GEOALDERO",
						"GEO_ALDER_",
						"ALDEROLD",
					}
				},
				new MpropField
				{
					DataModelName = "GEO_BI_MAINT",
					PropertyInfo = typeof(Property).GetProperty("GEO_BI_MAINT"),
					DataFileNames = new List<string>()
					{
						"GEO_BI_MAINT",
						"GEOBIMAINT",
						"GEO_BI_MAI",
						"BIMNTDIS",
					}
				},
				new MpropField
				{
					DataModelName = "GEO_BLOCK",
					PropertyInfo = typeof(Property).GetProperty("GEO_BLOCK"),
					DataFileNames = new List<string>()
					{
						"GEO_BLOCK",
						"GEOBLOCK",
						"CENBLOCK",
					}
				},
				new MpropField
				{
					DataModelName = "GEO_FIRE",
					PropertyInfo = typeof(Property).GetProperty("GEO_FIRE"),
					DataFileNames = new List<string>()
					{
						"GEO_FIRE",
						"GEOFIRE",
						"FIREDIST",
					}
				},
				new MpropField
				{
					DataModelName = "GEO_POLICE",
					PropertyInfo = typeof(Property).GetProperty("GEO_POLICE"),
					DataFileNames = new List<string>()
					{
						"GEO_POLICE",
						"GEOPOLICE",
						"POLICEDS",
					}
				},
				new MpropField
				{
					DataModelName = "GEO_TRACT",
					PropertyInfo = typeof(Property).GetProperty("GEO_TRACT"),
					DataFileNames = new List<string>()
					{
						"GEO_TRACT",
						"GEOTRACT",
						"CENTRACT",
					}
				},
				new MpropField
				{
					DataModelName = "GEO_ZIP_CODE",
					PropertyInfo = typeof(Property).GetProperty("GEO_ZIP_CODE"),
					DataFileNames = new List<string>()
					{
						"GEO_ZIP_CODE",
						"GEOZIPCODE",
						"GEO_ZIP_CO",
					}
				},
				new MpropField
				{
					DataModelName = "HIST_CODE",
					PropertyInfo = typeof(Property).GetProperty("HIST_CODE"),
					DataFileNames = new List<string>()
					{
						"HIST_CODE",
						"HISTCODE",
						"HISTDES",
					}
				},
				new MpropField
				{
					DataModelName = "HOUSE_NR_HI",
					PropertyInfo = typeof(Property).GetProperty("HOUSE_NR_HI"),
					DataFileNames = new List<string>()
					{
						"HOUSE_NR_HI",
						"HOUSENRHI",
						"HOUSE_NR_H",
						"HSNUMHI",
					}
				},
				new MpropField
				{
					DataModelName = "HOUSE_NR_LO",
					PropertyInfo = typeof(Property).GetProperty("HOUSE_NR_LO"),
					DataFileNames = new List<string>()
					{
						"HOUSE_NR_LO",
						"HOUSENRLO",
						"HOUSE_NR_L",
						"HSNUMLO",
					}
				},
				new MpropField
				{
					DataModelName = "HOUSE_NR_SFX",
					PropertyInfo = typeof(Property).GetProperty("HOUSE_NR_SFX"),
					DataFileNames = new List<string>()
					{
						"HOUSE_NR_SFX",
						"HOUSENRSFX",
						"HOUSE_NR_S",
						"HSNUMSUF",
					}
				},
				new MpropField
				{
					DataModelName = "LAND_USE",
					PropertyInfo = typeof(Property).GetProperty("LAND_USE"),
					DataFileNames = new List<string>()
					{
						"LAND_USE",
						"LANDUSE",
					}
				},
				new MpropField
				{
					DataModelName = "LAND_USE_GP",
					PropertyInfo = typeof(Property).GetProperty("LAND_USE_GP"),
					DataFileNames = new List<string>()
					{
						"LAND_USE_GP",
						"LANDUSEGP",
						"LAND_USE_G",
					}
				},
				new MpropField
				{
					DataModelName = "LAST_NAME_CHG",
					PropertyInfo = typeof(Property).GetProperty("LAST_NAME_CHG"),
					DataFileNames = new List<string>()
					{
						"LAST_NAME_CHG",
						"LASTNAMECH",
						"LAST_NAME_",
						"NAMCHDAT",
					}
				},
				new MpropField
				{
					DataModelName = "LAST_VALUE_CHG",
					PropertyInfo = typeof(Property).GetProperty("LAST_VALUE_CHG"),
					DataFileNames = new List<string>()
					{
						"LAST_VALUE_CHG",
						"LASTVALUE",
						"LAST_VALUE",
					}
				},
				new MpropField
				{
					DataModelName = "LOT_AREA",
					PropertyInfo = typeof(Property).GetProperty("LOT_AREA"),
					DataFileNames = new List<string>()
					{
						"LOT_AREA",
						"LOTAREA",
					}
				},
				new MpropField
				{
					DataModelName = "NEIGHBORHOOD",
					PropertyInfo = typeof(Property).GetProperty("NEIGHBORHOOD"),
					DataFileNames = new List<string>()
					{
						"NEIGHBORHOOD",
						"NEIGHBORHD",
						"NEIGHBORHO",
						"NBRHOOD",
					}
				},
				new MpropField
				{
					DataModelName = "NR_ROOMS",
					PropertyInfo = typeof(Property).GetProperty("NR_ROOMS"),
					DataFileNames = new List<string>()
					{
						"NR_ROOMS",
						"NRROOMS",
						"TOTROOMS",
					}
				},
				new MpropField
				{
					DataModelName = "NR_STORIES",
					PropertyInfo = typeof(Property).GetProperty("NR_STORIES"),
					DataFileNames = new List<string>()
					{
						"NR_STORIES",
						"NRSTORIES",
						"NSTORIES",
					}
				},
				new MpropField
				{
					DataModelName = "NR_UNITS",
					PropertyInfo = typeof(Property).GetProperty("NR_UNITS"),
					DataFileNames = new List<string>()
					{
						"NR_UNITS",
						"NRUNITS",
						"NUMUNITS",
					}
				},
				new MpropField
				{
					DataModelName = "OWN_OCPD",
					PropertyInfo = typeof(Property).GetProperty("OWN_OCPD"),
					DataFileNames = new List<string>()
					{
						"OWN_OCPD",
						"OWNOCPD",
						"OWNEROCC",
					}
				},
				new MpropField
				{
					DataModelName = "OWNER_CITY_STATE",
					PropertyInfo = typeof(Property).GetProperty("OWNER_CITY_STATE"),
					DataFileNames = new List<string>()
					{
						"OWNER_CITY_STATE",
						"OWNERCITY",
						"OWNER_CITY",
						"OWNRCITY",
					}
				},
				new MpropField
				{
					DataModelName = "OWNER_MAIL_ADDR",
					PropertyInfo = typeof(Property).GetProperty("OWNER_MAIL_ADDR"),
					DataFileNames = new List<string>()
					{
						"OWNER_MAIL_ADDR",
						"OWNERADDR",
						"OWNER_MAIL",
						"OWNRADDR",
					}
				},
				new MpropField
				{
					DataModelName = "OWNER_NAME_1",
					PropertyInfo = typeof(Property).GetProperty("OWNER_NAME_1"),
					DataFileNames = new List<string>()
					{
						"OWNER_NAME_1",
						"OWNERNAME1",
						"OWNRNAM1",
					}
				},
				new MpropField
				{
					DataModelName = "OWNER_NAME_2",
					PropertyInfo = typeof(Property).GetProperty("OWNER_NAME_2"),
					DataFileNames = new List<string>()
					{
						"OWNER_NAME_2",
						"OWNERNAME2",
						"OWNRNAM2",
					}
				},
				new MpropField
				{
					DataModelName = "OWNER_NAME_3",
					PropertyInfo = typeof(Property).GetProperty("OWNER_NAME_3"),
					DataFileNames = new List<string>()
					{
						"OWNER_NAME_3",
						"OWNERNAME3",
						"OWNRNAM3",
					}
				},
				new MpropField
				{
					DataModelName = "OWNER_ZIP",
					PropertyInfo = typeof(Property).GetProperty("OWNER_ZIP"),
					DataFileNames = new List<string>()
					{
						"OWNER_ZIP",
						"OWNERZIP",
						"OWNRZIP",
					}
				},
				new MpropField
				{
					DataModelName = "P_A_CLASS",
					PropertyInfo = typeof(Property).GetProperty("P_A_CLASS"),
					DataFileNames = new List<string>()
					{
						"P_A_CLASS",
						"PACLASS",
						"PRECLSCD",
					}
				},
				new MpropField
				{
					DataModelName = "P_A_EXM_IMPRV",
					PropertyInfo = typeof(Property).GetProperty("P_A_EXM_IMPRV"),
					DataFileNames = new List<string>()
					{
						"P_A_EXM_IMPRV",
						"PAEXMIMPRV",
						"P_A_EXM_IM",
						"PREEXIMP",
					}
				},
				new MpropField
				{
					DataModelName = "P_A_EXM_LAND",
					PropertyInfo = typeof(Property).GetProperty("P_A_EXM_LAND"),
					DataFileNames = new List<string>()
					{
						"P_A_EXM_LAND",
						"PAEXMLAND",
						"P_A_EXM_LA",
						"PREEXLND",
					}
				},
				new MpropField
				{
					DataModelName = "P_A_EXM_TOTAL",
					PropertyInfo = typeof(Property).GetProperty("P_A_EXM_TOTAL"),
					DataFileNames = new List<string>()
					{
						"P_A_EXM_TOTAL",
						"PAEXMTOTAL",
						"P_A_EXM_TO",
						"PREEXTOT",
					}
				},
				new MpropField
				{
					DataModelName = "P_A_EXM_TYPE",
					PropertyInfo = typeof(Property).GetProperty("P_A_EXM_TYPE"),
					DataFileNames = new List<string>()
					{
						"P_A_EXM_TYPE",
						"PAEXMTYPE",
						"P_A_EXM_TY",
						"PREEXMTP",
					}
				},
				new MpropField
				{
					DataModelName = "P_A_IMPRV",
					PropertyInfo = typeof(Property).GetProperty("P_A_IMPRV"),
					DataFileNames = new List<string>()
					{
						"P_A_IMPRV",
						"PAIMPRV",
						"PREIMPAS",
					}
				},
				new MpropField
				{
					DataModelName = "P_A_LAND",
					PropertyInfo = typeof(Property).GetProperty("P_A_LAND"),
					DataFileNames = new List<string>()
					{
						"P_A_LAND",
						"PALAND",
						"PRELNDAS",
					}
				},
				new MpropField
				{
					DataModelName = "P_A_SYMBOL",
					PropertyInfo = typeof(Property).GetProperty("P_A_SYMBOL"),
					DataFileNames = new List<string>()
					{
						"P_A_SYMBOL",
						"PASYMBOL",
						"PRESYMBL",
					}
				},
				new MpropField
				{
					DataModelName = "P_A_TOTAL",
					PropertyInfo = typeof(Property).GetProperty("P_A_TOTAL"),
					DataFileNames = new List<string>()
					{
						"P_A_TOTAL",
						"PATOTAL",
						"PRETOTAS",
					}
				},
				new MpropField
				{
					DataModelName = "PARKING_SPACES",
					PropertyInfo = typeof(Property).GetProperty("PARKING_SPACES"),
					DataFileNames = new List<string>()
					{
						"PARKING_SPACES",
						"NOFSPACES",
						"PARKING_SP",
					}
				},
				new MpropField
				{
					DataModelName = "PARKING_TYPE",
					PropertyInfo = typeof(Property).GetProperty("PARKING_TYPE"),
					DataFileNames = new List<string>()
					{
						"PARKING_TYPE",
						"PARKING_TY",
						"GARAGETP",
					}
				},
				new MpropField
				{
					DataModelName = "PLAT_PAGE",
					PropertyInfo = typeof(Property).GetProperty("PLAT_PAGE"),
					DataFileNames = new List<string>()
					{
						"PLAT_PAGE",
						"PLATPAGE",
					}
				},
				new MpropField
				{
					DataModelName = "POWDER_ROOMS",
					PropertyInfo = typeof(Property).GetProperty("POWDER_ROOMS"),
					DataFileNames = new List<string>()
					{
						"POWDER_ROOMS",
						"POWDERROOM",
						"POWDER_ROO",
						"PWDRROOM",
					}
				},
				new MpropField
				{
					DataModelName = "RAZE_STATUS",
					PropertyInfo = typeof(Property).GetProperty("RAZE_STATUS"),
					DataFileNames = new List<string>()
					{
						"RAZE_STATUS",
						"RAZESTATUS",
						"RAZE_STATU",
					}
				},
				new MpropField
				{
					DataModelName = "REASON_FOR_CHG",
					PropertyInfo = typeof(Property).GetProperty("REASON_FOR_CHG"),
					DataFileNames = new List<string>()
					{
						"REASON_FOR_CHG",
						"REASONFOR",
						"REASON_FOR",
						"REASFCHG",
					}
				},
				new MpropField
				{
					DataModelName = "SDIR",
					PropertyInfo = typeof(Property).GetProperty("SDIR"),
					DataFileNames = new List<string>()
					{
						"SDIR",
						"DIR",
						"STRTDIR",
					}
				},
				new MpropField
				{
					DataModelName = "STREET",
					PropertyInfo = typeof(Property).GetProperty("STREET"),
					DataFileNames = new List<string>()
					{
						"STREET",
						"STRTNAME",
					}
				},
				new MpropField
				{
					DataModelName = "STTYPE",
					PropertyInfo = typeof(Property).GetProperty("STTYPE"),
					DataFileNames = new List<string>()
					{
						"STTYPE",
						"STRTTYPE",
					}
				},
				new MpropField
				{
					DataModelName = "SUB_ACCT",
					PropertyInfo = typeof(Property).GetProperty("SUB_ACCT"),
					DataFileNames = new List<string>()
					{
						"SUB_ACCT",
						"SUBACCT",
					}
				},
				new MpropField
				{
					DataModelName = "SWIM_POOL",
					PropertyInfo = typeof(Property).GetProperty("SWIM_POOL"),
					DataFileNames = new List<string>()
					{
						"SWIM_POOL",
						"SWIMPOOL",
					}
				},
				new MpropField
				{
					DataModelName = "TAX_DELQ",
					PropertyInfo = typeof(Property).GetProperty("TAX_DELQ"),
					DataFileNames = new List<string>()
					{
						"TAX_DELQ",
						"TAXDELQ",
					}
				},
				new MpropField
				{
					DataModelName = "TAX_RATE_CD",
					PropertyInfo = typeof(Property).GetProperty("TAX_RATE_CD"),
					DataFileNames = new List<string>()
					{
						"TAX_RATE_CD",
						"TAXRATECD",
						"TAX_RATE_C",
						"TAXRATEC",
					}
				},
				new MpropField
				{
					DataModelName = "TAXKEY",
					PropertyInfo = typeof(Property).GetProperty("TAXKEY"),
					DataFileNames = new List<string>()
					{
						"TAXKEY",
					}
				},
				new MpropField
				{
					DataModelName = "YEARS_DELQ",
					PropertyInfo = typeof(Property).GetProperty("YEARS_DELQ"),
					DataFileNames = new List<string>()
					{
						"YEARS_DELQ",
						"Y",
					}
				},
				new MpropField
				{
					DataModelName = "YR_ASSMT",
					PropertyInfo = typeof(Property).GetProperty("YR_ASSMT"),
					DataFileNames = new List<string>()
					{
						"YR_ASSMT",
						"YRASSMT",
						"YEARASS",
					}
				},
				new MpropField
				{
					DataModelName = "YR_BUILT",
					PropertyInfo = typeof(Property).GetProperty("YR_BUILT"),
					DataFileNames = new List<string>()
					{
						"YR_BUILT",
						"YRBUILT",
					}
				},
				new MpropField
				{
					DataModelName = "ZONING",
					PropertyInfo = typeof(Property).GetProperty("ZONING"),
					DataFileNames = new List<string>()
					{
						"ZONING",
					}
				},
			};

			string[] files = Directory.GetFiles(@"M:\My Documents\GitHub\mpropsandbox\Data", "*.csv");
			List<Property> properties = new List<Property>();

			foreach (string file in files)
			{
				string fileNameShort = file.Substring(file.LastIndexOf("\\") + 1);
				fileNameShort = fileNameShort.Replace(".csv", "");

				string fileYearShort = fileNameShort;

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
					while (csvReader.Read())
					{
						Property property = new Property();
						property.Source = fileNameShort;

						foreach (MpropField mpropField in mpropFields)
						{
							if (mpropField.PropertyInfo.PropertyType == typeof(string))
							{
							}
						}
					}
				}
			}
		}

		static void GenerateMpropFields()
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

						if (field.Length > 1)
						{
							if (mpropField == null)
								mpropField = mpropFields.FirstOrDefault(x => x.DataFileNames.Any(x => x.Replace("_", "") == field));

							if (mpropField == null)
								mpropField = mpropFields.FirstOrDefault(x => x.DataFileNames.Any(x => x.Replace("_", "").StartsWith(field)));

							if (mpropField == null)
								mpropField = mpropFields.FirstOrDefault(x => x.DataFileNames.Any(x => x.StartsWith(field)));
						}

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
                            conflicts.Add(fileYear + " exists multiple times for field " + field + " (" + mpropField.DataModelName + ")");
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

            sb.AppendLine(new string('-', 40));
            sb.AppendLine("List<MpropField> mpropFields = new List<MpropField>()");
            sb.AppendLine("{");

            foreach (MpropField mpropField in mpropFields.Where(x => !string.IsNullOrEmpty(x.DataModelName)).OrderBy(x => x.DataModelName))
            {
                sb.AppendLine("\tnew MpropField");
                sb.AppendLine("\t{");
                sb.AppendLine("\t\tDataModelName = \"" + mpropField.DataModelName + "\",");
                sb.AppendLine("\t\tPropertyInfo = typeof(Property).GetProperty(\"" + mpropField.DataModelName + "\"),");
                sb.AppendLine("\t\tDataFileNames = new List<string>()");
                sb.AppendLine("\t\t{");
                foreach (string dataFileName in mpropField.DataFileNames)
                    sb.AppendLine("\t\t\t\"" + dataFileName + "\",");
                sb.AppendLine("\t\t}");
                sb.AppendLine("\t},");
            }

            sb.AppendLine("}");

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

				case "PERCTIMPRV": return "EXM_PER_CT_IMPRV";
				case "PERCTLAND": return "EXM_PER_CT_LAND";

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

				case "TAXDIST": return "TAX_RATE_CD";

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
