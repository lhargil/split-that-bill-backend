/*
  Source: https://gist.github.com/Chintan7027/fc4708d8b5c8d1639a7c
*/
CREATE DEFINER=`root`@`localhost` PROCEDURE `Add_Currencies`()
BEGIN
	IF NOT EXISTS (SELECT * 
	FROM information_schema.tables
	WHERE table_schema = DATABASE()
		AND table_name = 'Currencies'
	LIMIT 1) THEN
    CREATE TABLE Currencies(
	   Id              INT NOT NULL AUTO_INCREMENT PRIMARY KEY
	  ,Code            VARCHAR(3) NOT NULL
	  ,UnicodeDecimal  VARCHAR(20)
	  ,UnicodeHex      VARCHAR(17)
	  ,Name            VARCHAR(40) NOT NULL
	);
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('ALL','76, 101, 107','4c, 65, 6b','Albania Lek');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('AFN','1547','60b','Afghanistan Afghani');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('ARS','36','24','Argentina Peso');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('AWG','402','192','Aruba Guilder');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('AUD','36','24','Australia Dollar');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('AZN','1084, 1072, 1085','43c, 430, 43d','Azerbaijan New Manat');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('BSD','36','24','Bahamas Dollar');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('BBD','36','24','Barbados Dollar');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('BYR','112, 46','70, 2e','Belarus Ruble');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('BZD','66, 90, 36','42, 5a, 24','Belize Dollar');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('BMD','36','24','Bermuda Dollar');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('BOB','36, 98','24, 62','Bolivia Boliviano');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('BAM','75, 77','4b, 4d','Bosnia and Herzegovina Convertible Marka');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('BWP','80','50','Botswana Pula');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('BGN','1083, 1074','43b, 432','Bulgaria Lev');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('BRL','82, 36','52, 24','Brazil Real');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('BND','36','24','Brunei Darussalam Dollar');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('KHR','6107','17db','Cambodia Riel');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('CAD','36','24','Canada Dollar');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('KYD','36','24','Cayman Islands Dollar');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('CLP','36','24','Chile Peso');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('CNY','165','a5','China Yuan Renminbi');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('COP','36','24','Colombia Peso');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('CRC','8353','20a1','Costa Rica Colon');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('HRK','107, 110','6b, 6e','Croatia Kuna');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('CUP','8369','20b1','Cuba Peso');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('CZK','75, 269','4b, 10d','Czech Republic Koruna');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('DKK','107, 114','6b, 72','Denmark Krone');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('DOP','82, 68, 36','52, 44, 24','Dominican Republic Peso');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('XCD','36','24','East Caribbean Dollar');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('EGP','163','a3','Egypt Pound');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('SVC','36','24','El Salvador Colon');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('EEK','107, 114','6b, 72','Estonia Kroon');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('EUR','8364','20ac','Euro Member Countries');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('FKP','163','a3','Falkland Islands (Malvinas) Pound');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('FJD','36','24','Fiji Dollar');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('GHC','162','a2','Ghana Cedis');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('GIP','163','a3','Gibraltar Pound');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('GTQ','81','51','Guatemala Quetzal');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('GGP','163','a3','Guernsey Pound');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('GYD','36','24','Guyana Dollar');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('HNL','76','4c','Honduras Lempira');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('HKD','36','24','Hong Kong Dollar');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('HUF','70, 116','46, 74','Hungary Forint');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('ISK','107, 114','6b, 72','Iceland Krona');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('INR',NULL,NULL,'India Rupee');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('IDR','82, 112','52, 70','Indonesia Rupiah');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('IRR','65020','fdfc','Iran Rial');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('IMP','163','a3','Isle of Man Pound');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('ILS','8362','20aa','Israel Shekel');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('JMD','74, 36','4a, 24','Jamaica Dollar');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('JPY','165','a5','Japan Yen');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('JEP','163','a3','Jersey Pound');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('KZT','1083, 1074','43b, 432','Kazakhstan Tenge');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('KRW','8361','20a9','Korea (South) Won');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('KGS','1083, 1074','43b, 432','Kyrgyzstan Som');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('LAK','8365','20ad','Laos Kip');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('LVL','76, 115','4c, 73','Latvia Lat');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('LBP','163','a3','Lebanon Pound');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('LRD','36','24','Liberia Dollar');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('LTL','76, 116','4c, 74','Lithuania Litas');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('MKD','1076, 1077, 1085','434, 435, 43d','Macedonia Denar');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('MYR','82, 77','52, 4d','Malaysia Ringgit');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('MUR','8360','20a8','Mauritius Rupee');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('MXN','36','24','Mexico Peso');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('MNT','8366','20ae','Mongolia Tughrik');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('MZN','77, 84','4d, 54','Mozambique Metical');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('NAD','36','24','Namibia Dollar');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('NPR','8360','20a8','Nepal Rupee');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('ANG','402','192','Netherlands Antilles Guilder');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('NZD','36','24','New Zealand Dollar');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('NIO','67, 36','43, 24','Nicaragua Cordoba');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('NGN','8358','20a6','Nigeria Naira');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('KPW','8361','20a9','Korea (North) Won');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('NOK','107, 114','6b, 72','Norway Krone');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('OMR','65020','fdfc','Oman Rial');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('PKR','8360','20a8','Pakistan Rupee');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('PAB','66, 47, 46','42, 2f, 2e','Panama Balboa');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('PYG','71, 115','47, 73','Paraguay Guarani');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('PEN','83, 47, 46','53, 2f, 2e','Peru Nuevo Sol');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('PHP','8369','20b1','Philippines Peso');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('PLN','122, 322','7a, 142','Poland Zloty');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('QAR','65020','fdfc','Qatar Riyal');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('RON','108, 101, 105','6c, 65, 69','Romania New Leu');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('RUB','1088, 1091, 1073','440, 443, 431','Russia Ruble');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('SHP','163','a3','Saint Helena Pound');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('SAR','65020','fdfc','Saudi Arabia Riyal');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('RSD','1044, 1080, 1085, 46','414, 438, 43d, 2e','Serbia Dinar');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('SCR','8360','20a8','Seychelles Rupee');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('SGD','36','24','Singapore Dollar');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('SBD','36','24','Solomon Islands Dollar');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('SOS','83','53','Somalia Shilling');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('ZAR','82','52','South Africa Rand');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('LKR','8360','20a8','Sri Lanka Rupee');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('SEK','107, 114','6b, 72','Sweden Krona');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('CHF','67, 72, 70','43, 48, 46','Switzerland Franc');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('SRD','36','24','Suriname Dollar');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('SYP','163','a3','Syria Pound');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('TWD','78, 84, 36','4e, 54, 24','Taiwan New Dollar');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('THB','3647','e3f','Thailand Baht');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('TTD','84, 84, 36','54, 54, 24','Trinidad and Tobago Dollar');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('TRY',NULL,NULL,'Turkey Lira');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('TRL','8356','20a4','Turkey Lira');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('TVD','36','24','Tuvalu Dollar');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('UAH','8372','20b4','Ukraine Hryvna');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('GBP','163','a3','United Kingdom Pound');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('USD','36','24','United States Dollar');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('UYU','36, 85','24, 55','Uruguay Peso');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('UZS','1083, 1074','43b, 432','Uzbekistan Som');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('VEF','66, 115','42, 73','Venezuela Bolivar');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('VND','8363','20ab','Viet Nam Dong');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('YER','65020','fdfc','Yemen Rial');
INSERT INTO Currencies(Code,UnicodeDecimal,UnicodeHex,Name) VALUES ('ZWD','90, 36','5a, 24','Zimbabwe Dollar');
    END IF;
END
