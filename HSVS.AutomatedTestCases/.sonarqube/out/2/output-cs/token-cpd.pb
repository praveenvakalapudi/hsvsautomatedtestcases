Î
cD:\AccionLabs\Help\AutomatedTestCases\HSVS.AutomatedTestCases\HSVS.AutomatedTestCases.Dao\Class1.cs
	namespace 	
HSVS
 
. 
AutomatedTestCases !
.! "
Dao" %
{ 
public		 

class		 
Class1		 
{

 
} 
} ”@
lD:\AccionLabs\Help\AutomatedTestCases\HSVS.AutomatedTestCases\HSVS.AutomatedTestCases.Dao\DataAccessLayer.cs
	namespace 	
HSVS
 
. 
AutomatedTestCases !
.! "
Dao" %
{ 
public 

class 
DataAccessLayer  
{ 
public 
string 
_SourceConnection '
;' (
public 
string "
_DestinationConnection ,
;, -
readonly 
NpgsqlConnection !
sourceConnServer" 2
;2 3
readonly 
NpgsqlConnection !!
destinationConnServer" 7
;7 8
readonly 
LogFileHelper 
_logger &
;& '
public 
DataAccessLayer 
( 
)  
{ 	
_SourceConnection 
= 
Convert  '
.' (
ToString( 0
(0 1 
ConfigurationManager1 E
.E F
AppSettingsF Q
[Q R
$strR \
]\ ]
)] ^
;^ _"
_DestinationConnection "
=# $
Convert% ,
., -
ToString- 5
(5 6 
ConfigurationManager6 J
.J K
AppSettingsK V
[V W
$strW f
]f g
)g h
;h i
sourceConnServer 
= 
new "
NpgsqlConnection# 3
(3 4
_SourceConnection4 E
)E F
;F G!
destinationConnServer !
=" #
new$ '
NpgsqlConnection( 8
(8 9"
_DestinationConnection9 O
)O P
;P Q
_logger 
= 
new 
LogFileHelper '
(' (
)( )
;) *
} 	
public 
	DataTable #
GenericExecution_Source 0
(0 1
string1 7
sql8 ;
); <
{ 	
	DataTable 
dt 
= 
new 
	DataTable (
(( )
)) *
;* +
try   
{!! 
string"" 
message"" 
=""  
$str""! I
+""J K
sql""L O
;""O P
_logger## 
.## 
WriteToFile## #
(### $
message##$ +
)##+ ,
;##, -
if%% 
(%% 
sourceConnServer%% $
.%%$ %
State%%% *
==%%+ -
ConnectionState%%. =
.%%= >
Closed%%> D
)%%D E
sourceConnServer&& $
.&&$ %
Open&&% )
(&&) *
)&&* +
;&&+ ,
NpgsqlCommand'' 
command'' %
=''& '
sourceConnServer''( 8
.''8 9
CreateCommand''9 F
(''F G
)''G H
;''H I
command(( 
.(( 
CommandText(( #
=(($ %
sql((& )
;(() *
NpgsqlDataAdapter)) !
da))" $
=))% &
new))' *
NpgsqlDataAdapter))+ <
())< =
sql))= @
,))@ A
sourceConnServer))B R
)))R S
;))S T
da** 
.** 
Fill** 
(** 
dt** 
)** 
;** 
sourceConnServer++  
.++  !
Close++! &
(++& '
)++' (
;++( )
message-- 
=-- 
$str-- D
;--D E
_logger.. 
... 
WriteToFile.. #
(..# $
message..$ +
)..+ ,
;.., -
}// 
catch00 
(00 
	Exception00 
ex00 
)00  
{11 
_logger22 
.22 
WriteToFile22 #
(22# $
$str22$ V
+22W X
ex22Y [
.22[ \
Message22\ c
)22c d
;22d e
}33 
return44 
dt44 
;44 
}55 	
public77 
	DataTable77 (
GenericExecution_Destination77 5
(775 6
string776 <
sql77= @
)77@ A
{88 	
	DataTable99 
dt99 
=99 
new99 
	DataTable99 (
(99( )
)99) *
;99* +
try:: 
{;; 
string<< 
message<< 
=<<  
$str<<! N
+<<O P
sql<<Q T
;<<T U
_logger== 
.== 
WriteToFile== #
(==# $
message==$ +
)==+ ,
;==, -
if?? 
(?? !
destinationConnServer?? )
.??) *
State??* /
==??0 2
ConnectionState??3 B
.??B C
Closed??C I
)??I J!
destinationConnServer@@ )
.@@) *
Open@@* .
(@@. /
)@@/ 0
;@@0 1
NpgsqlCommandAA 
commandAA %
=AA& '!
destinationConnServerAA( =
.AA= >
CreateCommandAA> K
(AAK L
)AAL M
;AAM N
commandCC 
.CC 
CommandTextCC #
=CC$ %
sqlCC& )
;CC) *
NpgsqlDataAdapterDD !
daDD" $
=DD% &
newDD' *
NpgsqlDataAdapterDD+ <
(DD< =
sqlDD= @
,DD@ A!
destinationConnServerDDB W
)DDW X
;DDX Y
daEE 
.EE 
FillEE 
(EE 
dtEE 
)EE 
;EE !
destinationConnServerFF %
.FF% &
CloseFF& +
(FF+ ,
)FF, -
;FF- .
messageHH 
=HH 
$strHH I
;HHI J
_loggerII 
.II 
WriteToFileII #
(II# $
messageII$ +
)II+ ,
;II, -
}JJ 
catchKK 
(KK 
	ExceptionKK 
exKK 
)KK  
{LL 
_loggerMM 
.MM 
WriteToFileMM #
(MM# $
$strMM$ M
+MMN O
exMMP R
.MMR S
MessageMMS Z
)MMZ [
;MM[ \
}NN 
returnOO 
dtOO 
;OO 
}PP 	
publicRR 
	DataTableRR 
CustomQueryRR $
(RR$ %
stringRR% +
sqlRR, /
)RR/ 0
{SS 	
	DataTableTT 
dtTT 
=TT 
newTT 
	DataTableTT (
(TT( )
)TT) *
;TT* +
tryUU 
{VV 
dtWW 
=WW #
GenericExecution_SourceWW ,
(WW, -
sqlWW- 0
)WW0 1
;WW1 2
}XX 
catchYY 
(YY 
	ExceptionYY 
exYY 
)YY  
{ZZ 
_logger[[ 
.[[ 
WriteToFile[[ #
([[# $
$str[[$ @
+[[A B
ex[[C E
.[[E F
Message[[F M
)[[M N
;[[N O
}\\ 
return]] 
dt]] 
;]] 
}^^ 	
public`` 
	DataTable`` &
CleanTableData_Destination`` 3
(``3 4
string``4 :
	tableName``; D
)``D E
{aa 	
	DataTablebb 
dtbb 
=bb 
newbb 
	DataTablebb (
(bb( )
)bb) *
;bb* +
trycc 
{dd 
stringff 
sqlff 
=ff 
$strff .
+ff/ 0
	tableNameff1 :
+ff; <
$strff= @
;ff@ A
dtgg 
=gg (
GenericExecution_Destinationgg 1
(gg1 2
sqlgg2 5
)gg5 6
;gg6 7
}hh 
catchii 
(ii 
	Exceptionii 
exii 
)ii  
{jj 
_loggerkk 
.kk 
WriteToFilekk #
(kk# $
$strkk$ H
+kkI J
exkkK M
.kkM N
MessagekkN U
)kkU V
;kkV W
}ll 
returnmm 
dtmm 
;mm 
}nn 	
}oo 
}qq Ÿ
tD:\AccionLabs\Help\AutomatedTestCases\HSVS.AutomatedTestCases\HSVS.AutomatedTestCases.Dao\Properties\AssemblyInfo.cs
[ 
assembly 	
:	 

AssemblyTitle 
( 
$str 6
)6 7
]7 8
[		 
assembly		 	
:			 

AssemblyDescription		 
(		 
$str		 !
)		! "
]		" #
[

 
assembly

 	
:

	 
!
AssemblyConfiguration

  
(

  !
$str

! #
)

# $
]

$ %
[ 
assembly 	
:	 

AssemblyCompany 
( 
$str 
) 
] 
[ 
assembly 	
:	 

AssemblyProduct 
( 
$str 8
)8 9
]9 :
[ 
assembly 	
:	 

AssemblyCopyright 
( 
$str 0
)0 1
]1 2
[ 
assembly 	
:	 

AssemblyTrademark 
( 
$str 
)  
]  !
[ 
assembly 	
:	 

AssemblyCulture 
( 
$str 
) 
] 
[ 
assembly 	
:	 


ComVisible 
( 
false 
) 
] 
[ 
assembly 	
:	 

Guid 
( 
$str 6
)6 7
]7 8
[## 
assembly## 	
:##	 

AssemblyVersion## 
(## 
$str## $
)##$ %
]##% &
[$$ 
assembly$$ 	
:$$	 

AssemblyFileVersion$$ 
($$ 
$str$$ (
)$$( )
]$$) *