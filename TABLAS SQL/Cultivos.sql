Create database ERP
use ERP

create table SalesCultivos(
    idCultivo   int primary key,
	nombre   varchar(100) not null,
	costoAsesoria float not null,
	estatus  char not null,
)