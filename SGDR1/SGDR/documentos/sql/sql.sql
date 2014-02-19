/*
SQLyog - Free MySQL GUI v5.02
Host - 4.0.18-nt : Database - sgd_fnde
*********************************************************************
Server version : 4.0.18-nt
*/


USE `sgd_fnde`;

/*Table structure for table `assignments` */

DROP TABLE IF EXISTS `assignments`;

CREATE TABLE `assignments` (
  `id` mediumint(8) unsigned NOT NULL auto_increment,
  `task` mediumint(8) unsigned NOT NULL default '0',
  `owner` mediumint(8) unsigned NOT NULL default '0',
  `assigned_to` mediumint(8) unsigned NOT NULL default '0',
  `comments` text,
  `assigned` varchar(16) default NULL,
  `subtask` mediumint(8) unsigned NOT NULL default '0',
  PRIMARY KEY  (`id`)
) TYPE=MyISAM;

/*Data for the table `assignments` */

/*Table structure for table `ata_anexo` */

DROP TABLE IF EXISTS `ata_anexo`;

CREATE TABLE `ata_anexo` (
  `id` int(8) NOT NULL auto_increment,
  `tipo` int(1) default NULL,
  `titulo` varchar(155) default NULL,
  `documento` longblob,
  `id_ata` int(8) NOT NULL default '0',
  `data` varchar(16) default NULL,
  PRIMARY KEY  (`id`)
) TYPE=MyISAM;

/*Data for the table `ata_anexo` */

/*Table structure for table `ata_reuniao` */

DROP TABLE IF EXISTS `ata_reuniao`;

CREATE TABLE `ata_reuniao` (
  `id` int(8) NOT NULL auto_increment,
  `registro` int(11) default NULL,
  `data` varchar(16) default NULL,
  `setor` int(8) default NULL,
  `produto` longtext,
  `elaborado` int(8) default NULL,
  `area_elaborado` int(8) default NULL,
  `fone_elaborado` varchar(155) default NULL,
  `revisado` int(8) default NULL,
  `area_revisado` int(8) default NULL,
  `fone_revisado` varchar(155) default NULL,
  `ger_projeto` int(8) default NULL,
  `area_gerprojeto` int(8) default NULL,
  `fone_gerprojeto` varchar(155) default NULL,
  `cliente` varchar(255) default NULL,
  `responsavel` varchar(255) default NULL,
  `fone_cliente` varchar(155) default NULL,
  `situacao` varchar(255) default NULL,
  `solicita_cliente` longtext,
  `justificativa` longtext,
  `beneficio` longtext,
  `sistem_envovido` longtext,
  `tecnologias` longtext,
  `modelo_negocio` longtext,
  `area_envolvida` longtext,
  `cenario` longtext,
  `riscos` longtext,
  `lancamento` longtext,
  `homologacao` longtext,
  `conograma` longtext,
  `suporte` longtext,
  `treinamento` int(1) default NULL,
  `tipo_treino` int(1) default NULL,
  `manual` int(1) default NULL,
  `tipo_manual` int(1) default NULL,
  `conclusao` longtext,
  `id_projeto` int(8) NOT NULL default '0',
  `id_relaciona` int(8) NOT NULL default '0',
  `cordena` varchar(100) default NULL,
  `area_cordena` varchar(100) default NULL,
  `fone_cordena` varchar(100) default NULL,
  `aceite` int(1) default NULL,
  `data_aceite` varchar(16) default NULL,
  `owner_aceite` int(1) default NULL,
  PRIMARY KEY  (`id`)
) TYPE=MyISAM;

/*Data for the table `ata_reuniao` */

insert into `ata_reuniao` values 
(1,NULL,'2007-02-12',NULL,'',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'nao mostra dados',NULL,NULL,'nao mostra dados','nao mostra dados','nao mostra dados','nao mostra dados','nao mostra dados','nao mostra dados','nao mostra dados','nao mostra dados','nao mostra dados','nao mostra dados','nao mostra dados','nao mostra dados','nao mostra dados','nao mostra dados',0,0,0,0,'nao mostra dadosnao mostra dadosnao mostra dadosnao mostra dados',4,2,NULL,NULL,NULL,NULL,NULL,NULL),
(2,NULL,'2007-02-12',NULL,'',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'TESTE 3TESTE 3TESTE 3TESTE 3',NULL,NULL,'TESTE 3TESTE 3TESTE 3TESTE 3','TESTE 3TESTE 3TESTE 3TESTE 3','TESTE 3TESTE 3TESTE 3TESTE 3','TESTE 3TESTE 3TESTE 3TESTE 3','TESTE 3TESTE 3TESTE 3TESTE 3','TESTE 3TESTE 3TESTE 3TESTE 3','TESTE 3TESTE 3TESTE 3TESTE 3','TESTE 3TESTE 3TESTE 3TESTE 3','TESTE 3TESTE 3TESTE 3TESTE 3','TESTE 3TESTE 3TESTE 3TESTE 3','TESTE 3TESTE 3TESTE 3TESTE 3','TESTE 3TESTE 3TESTE 3TESTE 3','TESTE 3TESTE 3TESTE 3TESTE 3','TESTE 3TESTE 3TESTE 3TESTE 3',1,0,0,0,'TESTE 3TESTE 3TESTE 3TESTE 3TESTE 3TESTE 3TESTE 3TESTE 3TESTE 3TESTE 3TESTE 3TESTE 3TESTE 3TESTE 3TESTE 3TESTE 3',5,2,NULL,NULL,NULL,NULL,NULL,NULL),
(3,NULL,'2007-02-26',NULL,'',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'',NULL,NULL,'','','','','','','','','','','','','','',0,0,0,0,'',7,1,NULL,NULL,NULL,NULL,NULL,NULL),
(4,NULL,'2007-03-07',NULL,'',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'Rogério de Souza Leitão CGETI ramal: 4584',NULL,NULL,'Falta de controle pela TI das demandas geradas pelas áreas usuárias, falta de informalidade nas solicitações, demandas sempre urgentes e de difícil priorização.','Eu, Rogério de Souza Leitão percebendo a necessidade da Coordenação de Relacionamento e Atendimento idealizei um sistema que fosse capaz de gerenciar as demandas de forma eficiente através de um sistema de gestão de demandas - SGD.','Desenvolver um sistema em software livre que atenda as necessidades da Coordenação Geral de TI do FNDE, a fim de que fique alinhado com as políticas de TI do governo federal.','Maior organização do trabalho na TI\r\nMelhor relacionamento com o cliente de TI\r\nMaior controle das demandas\r\nFornecimento de base para tomada de decisão','Sistemas internos das CGETI como SRH e SEGWEB','PHP 5.0 , Linux, My SQL, Oracle e Windows.','Pavilhão de Metas','Todas as área do FNDE','Criar um sistema baseado nas metodologias ITIL, PMBOK e conceitos de governança de TI.','Mudança da política de governo','julho de 2006','Deve conter relatórios, logs de acesso e perfis de consulta gerencial','Entrega integral\r\n','Necessidade de adaptar banco de dados proprietário para banco de dados baseado em software livre, bem como adaptar o sistema de segurança corporativo.',1,0,1,0,'O Sistema de Gestão de Demandas possui o conceito de software livre e para tal foram utilizados como referências aplicativos open source já existentes do mercado como PHPCollab, Dot Project, GanttProject bem como o antigo sistema de registro de demandas do FNDE chamado Solicita, desenvolvido em linguagem ASP.\r\n	A prática de gestão de demandas está diretamente ligada ao Plano Diretor de Tecnologia e Informática do FNDE que prevê que os seus produtos e serviços desenvolvidos pela área de TI estejam aderentes as melhores práticas através de metodologias voltadas a Infra Estrutura e Serviços como ITIL (Information Technology Infraestructure Library) de gestão de projetos como PMI (Project Management Institute) ao COBIT relacionado a Governança de TI e a norma de segurança ISO 17799.\r\n',8,1,NULL,NULL,NULL,NULL,NULL,NULL);

/*Table structure for table `calendar` */

DROP TABLE IF EXISTS `calendar`;

CREATE TABLE `calendar` (
  `id` int(8) NOT NULL auto_increment,
  `owner` int(8) default NULL,
  `id_organizacao` int(8) default NULL,
  `id_project` int(8) NOT NULL default '0',
  `subject` varchar(155) default NULL,
  `description` varchar(200) default NULL,
  `shortname` varchar(155) default NULL,
  `date_start` varchar(10) default NULL,
  `date_end` varchar(10) default NULL,
  `time_start` varchar(155) default NULL,
  `time_end` varchar(155) default NULL,
  `reminder` char(1) NOT NULL default '',
  `recurring` char(1) NOT NULL default '',
  `recur_day` char(1) NOT NULL default '',
  `broadcast` char(1) NOT NULL default '',
  `location` varchar(155) default NULL,
  PRIMARY KEY  (`id`)
) TYPE=MyISAM;

/*Data for the table `calendar` */

insert into `calendar` values 
(1,0,0,0,'','','','','','','','','','','','');

/*Table structure for table `calender_reuniao` */

DROP TABLE IF EXISTS `calender_reuniao`;

CREATE TABLE `calender_reuniao` (
  `id` int(8) NOT NULL auto_increment,
  `titulo` varchar(100) default NULL,
  `id_calendar` int(8) default NULL,
  `id_projeto` int(8) default NULL,
  `data` varchar(16) default NULL,
  `arquivo` varchar(255) default NULL,
  PRIMARY KEY  (`id`)
) TYPE=MyISAM;

/*Data for the table `calender_reuniao` */

/*Table structure for table `fase_pendente` */

DROP TABLE IF EXISTS `fase_pendente`;

CREATE TABLE `fase_pendente` (
  `id` int(8) NOT NULL auto_increment,
  `id_fase` int(8) NOT NULL default '0',
  `id_projeto` int(8) NOT NULL default '0',
  `descricao` longtext,
  PRIMARY KEY  (`id`)
) TYPE=MyISAM;

/*Data for the table `fase_pendente` */

insert into `fase_pendente` values 
(1,0,7,'gfdsgdsfgfdsgfds gfds gdsfgsdf gdfsgfds gdfs gdfsgdsfg dsgdsf gdsf gdfsg dsgd fsgfds gsdfgfdsgfds gdfsgsdfgsdfgdfs gdsf gdfsgdsfgfdsgfdsg dsgfds gsdf gdsf gdsf gsdfgsdfgfdsgfdsgfdsgfdsgfd.'),
(2,0,7,'teste'),
(3,0,7,'teste'),
(4,0,7,'teste fsdafsad fdsa fdsafds'),
(5,21,7,'hgfdhgfd h hd hdh fdh g'),
(6,21,7,'hgfdhgfd h hd hdh fdh g');

/*Table structure for table `fases` */

DROP TABLE IF EXISTS `fases`;

CREATE TABLE `fases` (
  `id` int(8) NOT NULL auto_increment,
  `data_ini_plan` varchar(16) default NULL,
  `data_fim_plan` varchar(16) default NULL,
  `data_ini_real` varchar(16) default NULL,
  `data_fim_real` varchar(16) default NULL,
  `id_projeto` int(8) NOT NULL default '0',
  `tipo_fase` int(10) default NULL,
  `status_fase` int(10) default NULL,
  `data_fase` varchar(16) default NULL,
  PRIMARY KEY  (`id`)
) TYPE=MyISAM;

/*Data for the table `fases` */

insert into `fases` values 
(12,'','','','',5,6,0,'12-02-2007'),
(11,'2007-02-26','2007-02-26','2007-02-26','2007-02-26',5,5,2,'12-02-2007'),
(10,'','','','',5,4,0,'12-02-2007'),
(9,'','','','',5,3,0,'12-02-2007'),
(8,'2007-02-12','2007-02-12','2007-02-12','2007-02-12',5,1,2,'12-02-2007'),
(13,'2007-02-26','2007-02-26','2007-02-26','2007-02-26',5,7,2,'12-02-2007'),
(14,'2007-02-14','2007-02-14','2007-02-14','2007-02-14',3,1,0,'14-02-2007'),
(15,'','','','',3,2,0,NULL),
(16,'','','','',3,3,0,NULL),
(17,'','','','',3,4,0,NULL),
(18,'','','','',3,5,0,NULL),
(19,'','','','',3,6,0,NULL),
(20,'2007-02-15','2007-02-15','2007-02-15','2007-02-15',3,7,0,NULL),
(21,'2007-02-26','2007-02-28','2007-03-28','2007-04-29',7,1,0,'26-02-2007'),
(22,'','','','',7,2,0,NULL),
(23,'','','','',7,3,0,NULL),
(24,'','','','',7,4,0,NULL),
(25,'','','','',7,5,0,NULL),
(26,'','','','',7,6,0,NULL),
(27,'','','','',7,7,0,NULL);

/*Table structure for table `logs` */

DROP TABLE IF EXISTS `logs`;

CREATE TABLE `logs` (
  `id` int(8) NOT NULL auto_increment,
  `login` varchar(155) default NULL,
  `password` varchar(155) default NULL,
  `ip` varchar(155) default NULL,
  `session` varchar(155) default NULL,
  `compt` int(8) NOT NULL default '0',
  `last_visite` varchar(16) default NULL,
  `connected` varchar(255) default NULL,
  PRIMARY KEY  (`id`)
) TYPE=MyISAM;

/*Data for the table `logs` */

insert into `logs` values 
(1,'JANE',NULL,'172.20.67.74','7csqi4h4gat49uvt0b2hjhp573',365,'','%ld'),
(2,'ANA',NULL,'172.20.66.99','n90p7u1gf3i6sh6timaj96f8l7',13,'',''),
(3,'ARY',NULL,'172.20.67.74','7csqi4h4gat49uvt0b2hjhp573',22,'','%ld'),
(4,'MARRA',NULL,'172.20.67.74','7csqi4h4gat49uvt0b2hjhp573',95,'',''),
(5,'TESTE',NULL,'172.20.67.74','6gdc91ep12ga2k9qm42j14vum7',3,'',''),
(6,'PC',NULL,'172.20.67.74','6gdc91ep12ga2k9qm42j14vum7',5,'',''),
(7,'FLAMENGO',NULL,'172.20.67.74','7csqi4h4gat49uvt0b2hjhp573',1,'','');

/*Table structure for table `members` */

DROP TABLE IF EXISTS `members`;

CREATE TABLE `members` (
  `id` int(8) NOT NULL auto_increment,
  `organization` int(8) default NULL,
  `login` varchar(155) default NULL,
  `password` varchar(155) default NULL,
  `name` varchar(155) default NULL,
  `title` varchar(155) default NULL,
  `email_work` varchar(155) default NULL,
  `email_home` varchar(155) default NULL,
  `phone_work` varchar(155) default NULL,
  `phone_home` varchar(155) default NULL,
  `mobile` varchar(155) default NULL,
  `fax` varchar(155) default NULL,
  `comments` varchar(255) default NULL,
  `profil` char(2) NOT NULL default '',
  `created` varchar(240) default NULL,
  `logout_time` int(8) default NULL,
  `last_page` varchar(255) default NULL,
  `timezone` char(3) default NULL,
  PRIMARY KEY  (`id`)
) TYPE=MyISAM;

/*Data for the table `members` */

insert into `members` values 
(1,1,'JANE','JANE','JANE','JANE','jane@fnde.gov.br','jane@fnde.gov.br','778','776','','','','6','',0,'projects/listprojects.php?',''),
(2,1,'ANA','ANA','ANA','ANA','ana@fnde.gov.br','','8854','','','','','7','',0,'projects/listprojects.php?',''),
(3,1,'ARY','ARY','ARY','ARY','ary@fnde.gov.br','ary@fnde.gov.br','775','456','','','','3','',0,'projects_site/home.php?',''),
(4,1,'MARRA','MARRA','MARRA','MARRA','marra@fnde.gov.br','marra@fnde.gov.br','771','222','','','','1','',0,'projects_site/home.php?',''),
(5,1,'TESTE','TESTE','TESTE','TESTE','teste@teste.gov.br','teste@teste.gov.br','111','222','','','','6','',0,'',''),
(6,1,'PC','PC','PC','PC','pc@fnde.gov.br','pc@fnde.gov.br','812','812','','','','10','',0,'',''),
(7,1,'FLAMENGO','123456','FLAMENGO MESMO ASSIM E TIMINHO','FLAMENGO','fulanobr@bol.com.br',NULL,'8852',NULL,NULL,NULL,NULL,'10','2007-02-26',NULL,'projects/listprojects.php?',NULL),
(9,1,'manoel','123456','manoel do ceu','manoel','m@m',NULL,'7785',NULL,NULL,NULL,NULL,'6','2007-02-26',NULL,NULL,NULL),
(10,1,'utyut','tyutyu','utyutu','utyut','utyut',NULL,'7752',NULL,NULL,NULL,NULL,'6','2007-02-26',NULL,NULL,NULL),
(11,1,'JOAO','123','JOAO','JOAO','JOAO',NULL,'3213',NULL,NULL,NULL,NULL,'1','2007-03-07',NULL,NULL,NULL),
(12,1,'JOAO','123','JOAO','JOAO','JOAO',NULL,'1234',NULL,NULL,NULL,NULL,'1','2007-03-07',NULL,NULL,NULL);

/*Table structure for table `organizations` */

DROP TABLE IF EXISTS `organizations`;

CREATE TABLE `organizations` (
  `id` int(8) NOT NULL auto_increment,
  `name` varchar(255) default NULL,
  `address1` varchar(255) default NULL,
  `address2` varchar(255) default NULL,
  `zip_code` varchar(155) default NULL,
  `city` varchar(155) default NULL,
  `country` varchar(155) default NULL,
  `phone` varchar(155) default NULL,
  `fax` varchar(155) default NULL,
  `url` varchar(255) default NULL,
  `email` varchar(155) default NULL,
  `comments` varchar(255) default NULL,
  `created` varchar(16) default NULL,
  `extension_logo` char(3) NOT NULL default '',
  `owner` int(8) NOT NULL default '0',
  `hourly_rate` int(6) NOT NULL default '0',
  PRIMARY KEY  (`id`)
) TYPE=MyISAM;

/*Data for the table `organizations` */

insert into `organizations` values 
(1,'CGTI','','','','','','','','','','','2006-12-01','',0,0);

/*Table structure for table `projects` */

DROP TABLE IF EXISTS `projects`;

CREATE TABLE `projects` (
  `id` int(8) NOT NULL auto_increment,
  `organization` int(8) NOT NULL default '0',
  `owner` int(8) NOT NULL default '0',
  `priority` int(8) NOT NULL default '0',
  `status` int(8) NOT NULL default '0',
  `name` varchar(155) default NULL,
  `description` varchar(255) default NULL,
  `url_dev` varchar(255) default NULL,
  `url_prod` varchar(255) default NULL,
  `created` varchar(16) default NULL,
  `modified` varchar(16) default NULL,
  `published` char(1) NOT NULL default '',
  `upload_max` varchar(155) default NULL,
  `phase_set` int(8) NOT NULL default '0',
  `invoicing` char(1) NOT NULL default '',
  `hourly_rate` int(6) NOT NULL default '0',
  `tipo_demanda` char(1) default NULL,
  `prazo_status` char(1) default NULL,
  `id_relacionamento` int(8) default NULL,
  `id_ger_pro` int(8) default NULL,
  `id_cora` int(8) default NULL,
  `id_analista` int(8) default NULL,
  `id_fabrica` int(8) default NULL,
  `id_cordenacao` int(8) default NULL,
  `id_sistema` int(8) default NULL,
  `erro` mediumblob,
  PRIMARY KEY  (`id`)
) TYPE=MyISAM;

/*Data for the table `projects` */

insert into `projects` values 
(1,1,1,2,10,'Desenvolver script','','0','','2007-01-15 15:31','','0','51200',1,'0',1,'1','1',0,4,0,0,0,0,1,NULL),
(2,1,3,2,3,'Desenvolver script','','0','','2007-01-15 15:31','','0','51200',1,'0',1,'1','1',0,4,0,2,0,0,1,NULL),
(3,1,1,2,3,'Desenvolver script','','0','','2007-01-15 15:36','','0','51200',1,'0',1,'1','3',0,4,0,2,0,2,1,NULL),
(4,1,1,3,4,'nao mostra dados','','0',NULL,'2007-02-12 13:57',NULL,'0','51200',1,'0',1,'2','1',NULL,0,NULL,2,NULL,NULL,1,NULL),
(5,1,3,3,4,'TESTE 3','','3','','2007-02-12 14:28','','0','51200',1,'0',1,'2','2',0,4,0,2,0,2,2,NULL),
(6,1,3,2,12,'TESTE 3','teste','0','','2007-02-13 10:21','','0','51200',1,'1',1,'1','1',0,0,0,2,0,2,1,NULL),
(7,1,1,3,2,'Teste New','Período de Ferias','0','','2007-02-23 14:53','','0','51200',1,'0',1,'2','1',0,0,0,0,0,0,2,NULL),
(8,1,1,3,3,'Implementar OO','','4','','2007-02-26 11:36','','0','51200',1,'0',1,'0','1',0,6,0,2,0,2,0,NULL),
(9,1,1,2,3,'dsadsa','',NULL,NULL,'2007-03-07 14:45',NULL,'0','51200',1,'0',1,'1','1',NULL,NULL,NULL,NULL,NULL,NULL,1,NULL),
(10,1,1,2,3,'fsd','',NULL,NULL,'2007-03-07 14:51',NULL,'0','51200',1,'0',1,'0','1',NULL,NULL,NULL,NULL,NULL,NULL,0,NULL),
(11,1,1,0,3,'tese','',NULL,NULL,'2007-03-08 14:29',NULL,'0','51200',1,'0',1,'1','1',NULL,NULL,NULL,NULL,NULL,NULL,1,NULL),
(12,1,1,2,3,'este','',NULL,NULL,'2007-03-08 15:09',NULL,'0','51200',1,'0',1,'1','1',NULL,NULL,NULL,NULL,NULL,NULL,1,NULL),
(13,1,1,2,3,'fsdfds','',NULL,NULL,'2007-03-08 15:19',NULL,'0','51200',1,'0',1,'1','1',NULL,NULL,NULL,NULL,NULL,NULL,1,NULL),
(14,1,1,2,3,'dd','',NULL,NULL,'2007-03-08 15:22',NULL,'0','51200',1,'0',1,'3','1',NULL,NULL,NULL,NULL,NULL,NULL,0,NULL),
(15,1,1,2,3,'jhy','',NULL,NULL,'2007-03-08 15:24',NULL,'0','51200',1,'0',1,'1','1',NULL,NULL,NULL,NULL,NULL,NULL,1,NULL);

/*Table structure for table `projects_corretiva` */

DROP TABLE IF EXISTS `projects_corretiva`;

CREATE TABLE `projects_corretiva` (
  `id` int(8) NOT NULL auto_increment,
  `descricao` varchar(200) default NULL,
  `erro` varchar(100) default NULL,
  `id_projeto` int(8) NOT NULL default '0',
  PRIMARY KEY  (`id`)
) TYPE=MyISAM;

/*Data for the table `projects_corretiva` */

insert into `projects_corretiva` values 
(1,'OKOKI2','../erro/2/Doc2.doc',2),
(2,'sfsfsfsfsfsfsdf','../erro/6/alteracao_frequencia_jarf.doc',6);

/*Table structure for table `s_control_in` */

DROP TABLE IF EXISTS `s_control_in`;

CREATE TABLE `s_control_in` (
  `nu_seq_id` int(8) NOT NULL auto_increment,
  `an_date` varchar(16) NOT NULL default '',
  `st_status` char(2) NOT NULL default '',
  `id_projects` int(8) NOT NULL default '0',
  `ds_processo` varchar(255) NOT NULL default '',
  `md_documento` varchar(255) NOT NULL default '',
  PRIMARY KEY  (`nu_seq_id`)
) TYPE=MyISAM;

/*Data for the table `s_control_in` */

insert into `s_control_in` values 
(1,'2007-01-15','2',0,'Log de Autenticação','../anexo/log/20070115/200701151103aut.txt'),
(2,'2007-01-15','2',0,'Log de Autenticação','../anexo/log/20070115/200701151103aut.txt'),
(3,'2007-01-15','2',0,'Log de Autenticação','../anexo/log/20070115/200701151103aut.txt'),
(4,'2007-01-15','2',0,'Log de Autenticação','../anexo/log/20070115/200701151103aut.txt'),
(5,'2007-01-15','2',0,'Log de Autenticação','../anexo/log/20070115/200701151103aut.txt'),
(6,'2007-01-15','2',0,'Log de Autenticação','../anexo/log/20070115/200701151103aut.txt'),
(7,'2007-01-15','2',0,'Log de Autenticação','../anexo/log/20070115/200701151103aut.txt'),
(8,'2007-01-15','2',0,'Log de Autenticação','../anexo/log/20070115/200701151103aut.txt'),
(9,'2007-01-15','2',0,'Log de Autenticação','../anexo/log/20070115/200701151103aut.txt'),
(10,'2007-01-15','2',100,'Log de Autenticação','../anexo/log/20070115/200701151103aut.txt'),
(11,'2007-01-15','2',0,'Log de Autenticação','../anexo/log/20070115/200701151106aut.txt'),
(12,'2007-01-15','2',0,'Log de Autenticação','../anexo/log/20070115/200701151106aut.txt'),
(13,'2007-01-15','2',0,'Log de Autenticação','../anexo/log/20070115/200701151106aut.txt'),
(14,'2007-01-15','2',0,'Log de Autenticação','../anexo/log/20070115/200701151106aut.txt'),
(15,'2007-01-15','2',0,'Log de Autenticação','../anexo/log/20070115/200701151106aut.txt'),
(16,'2007-01-15','2',0,'Log de Autenticação','../anexo/log/20070115/200701151106aut.txt'),
(17,'2007-01-15','2',0,'Log de Autenticação','../anexo/log/20070115/200701151106aut.txt'),
(18,'2007-01-15','2',0,'Log de Autenticação','../anexo/log/20070115/200701151106aut.txt'),
(19,'2007-01-15','2',0,'Log de Autenticação','../anexo/log/20070115/200701151106aut.txt'),
(20,'2007-01-15','2',100,'Log de Autenticação','../anexo/log/20070115/200701151106aut.txt'),
(21,'2007-01-15','2',0,'Log de Autenticação','../anexo/log/20070115/200701151107aut.txt'),
(22,'2007-01-15','2',0,'Log de Autenticação','../anexo/log/20070115/200701151107aut.txt'),
(23,'2007-01-15','2',0,'Log de Autenticação','../anexo/log/20070115/200701151107aut.txt'),
(24,'2007-01-15','2',0,'Log de Autenticação','../anexo/log/20070115/200701151107aut.txt'),
(25,'2007-01-15','2',0,'Log de Autenticação','../anexo/log/20070115/200701151107aut.txt'),
(26,'2007-01-15','2',0,'Log de Autenticação','../anexo/log/20070115/200701151107aut.txt'),
(27,'2007-01-15','2',0,'Log de Autenticação','../anexo/log/20070115/200701151107aut.txt'),
(28,'2007-01-15','2',0,'Log de Autenticação','../anexo/log/20070115/200701151107aut.txt'),
(29,'2007-01-15','2',0,'Log de Autenticação','../anexo/log/20070115/200701151107aut.txt'),
(30,'2007-01-15','2',100,'Log de Autenticação','../anexo/log/20070115/200701151107aut.txt'),
(31,'2007-01-15','2',0,'Log de Autenticação','../anexo/log/20070115/200701151238aut.txt'),
(32,'2007-01-15','2',0,'Log de Autenticação','../anexo/log/20070115/200701151238aut.txt'),
(33,'2007-01-15','2',0,'Log de Autenticação','../anexo/log/20070115/200701151238aut.txt'),
(34,'2007-01-15','2',0,'Log de Autenticação','../anexo/log/20070115/200701151238aut.txt'),
(35,'2007-01-15','2',0,'Log de Autenticação','../anexo/log/20070115/200701151238aut.txt'),
(36,'2007-01-15','2',0,'Log de Autenticação','../anexo/log/20070115/200701151238aut.txt'),
(37,'2007-01-15','2',0,'Log de Autenticação','../anexo/log/20070115/200701151238aut.txt'),
(38,'2007-01-15','2',0,'Log de Autenticação','../anexo/log/20070115/200701151238aut.txt'),
(39,'2007-01-15','2',0,'Log de Autenticação','../anexo/log/20070115/200701151238aut.txt'),
(40,'2007-01-15','2',100,'Log de Autenticação','../anexo/log/20070115/200701151238aut.txt'),
(41,'2007-01-15','2',100,'Log de Autenticação','../anexo/log/20070115/200701151242aut.txt'),
(42,'2007-01-15','2',100,'Log de Autenticação','../anexo/log/20070115/200701151301aut.txt'),
(43,'2007-01-15','2',100,'Log de Autenticação','../anexo/log/20070115/200701151302aut.txt'),
(44,'2007-01-15','2',0,'Log de Autenticação','../anexo/log/20070115/200701151303aut.txt'),
(45,'2007-01-15','2',0,'Log de Autenticação','../anexo/log/20070115/200701151303aut.txt'),
(46,'2007-01-15','2',0,'Log de Autenticação','../anexo/log/20070115/200701151303aut.txt'),
(47,'2007-01-15','2',0,'Log de Autenticação','../anexo/log/20070115/200701151303aut.txt'),
(48,'2007-01-15','2',0,'Log de Autenticação','../anexo/log/20070115/200701151303aut.txt'),
(49,'2007-01-15','2',0,'Log de Autenticação','../anexo/log/20070115/200701151303aut.txt'),
(50,'2007-01-15','2',0,'Log de Autenticação','../anexo/log/20070115/200701151303aut.txt'),
(51,'2007-01-15','2',0,'Log de Autenticação','../anexo/log/20070115/200701151303aut.txt'),
(52,'2007-01-15','2',0,'Log de Autenticação','../anexo/log/20070115/200701151303aut.txt'),
(53,'2007-01-15','2',100,'Log de Autenticação','../anexo/log/20070115/200701151303aut.txt'),
(54,'2007-01-15','1',1,'Solicitação de Demanda','../anexo/log/20070115/200701151831.txt'),
(55,'2007-01-15','3',1,'Solicita Demanda','../anexo/log/20070115/200701151831[B unimplemented].txt'),
(56,'2007-01-15','1',2,'Solicitação de Demanda','../anexo/log/20070115/200701151831.txt'),
(57,'2007-01-15','3',2,'Solicita Demanda','../anexo/log/20070115/200701151831[B unimplemented].txt'),
(58,'2007-02-12','1',4,'Solicitação de Demanda','../anexo/log/20070212/200702121657.txt'),
(59,'2007-02-12','1',4,'Em Analise','../anexo/log/20070212/200702121705.txt'),
(60,'2007-02-12','1',4,'Validado pelo Relacionamento','../anexo/log/20070212/200702121706.txt'),
(61,'2007-02-12','3',4,'Validado pelo Relacionamento','../anexo/log/20070212/200702121706[B unimplemented]vt.txt'),
(62,'2007-02-12','1',5,'Solicitação de Demanda','../anexo/log/20070212/200702121728.txt'),
(63,'2007-02-12','3',5,'Alterado Gestor','../anexo/log/20070212/200702121847[B unimplemented].txt'),
(64,'2007-02-12','3',5,'Validado pela TI','../anexo/log/20070212/200702121847[B unimplemented]vt.txt'),
(65,'2007-02-12','3',5,'Alterado Gestor','../anexo/log/20070212/200702121847[B unimplemented].txt'),
(66,'2007-02-12','1',5,'Validado pelo Relacionamento','../anexo/log/20070212/200702121847.txt'),
(67,'2007-02-12','3',5,'Validado pelo Relacionamento','../anexo/log/20070212/200702121847[B unimplemented]vt.txt'),
(68,'2007-02-12','1',5,'Atribuida pelo Coordenador da Fabrica','../anexo/log/20070212/200702121848.txt'),
(69,'2007-02-12','1',5,'Atribuida pelo Coordenador da Fabrica','../anexo/log/20070212/200702121849.txt'),
(70,'2007-02-13','1',5,'Em Homologação','../anexo/log/20070213/200702131235.txt'),
(71,'2007-02-13','1',5,'Homologação Concluida','../anexo/log/20070213/200702131236.txt'),
(72,'2007-02-13','3',5,'Homologação Concluida','../anexo/log/20070213/200702131236[B unimplemented].txt'),
(73,'2007-02-13','1',6,'Solicitação de Demanda','../anexo/log/20070213/200702131321.txt'),
(74,'2007-02-14','1',5,'Homologação Concluida','../anexo/log/20070214/200702141331.txt'),
(75,'2007-02-14','3',5,'Homologação Concluida','../anexo/log/20070214/200702141331[B unimplemented].txt'),
(76,'2007-02-14','1',5,'Homologação Concluida','../anexo/log/20070214/200702141334.txt'),
(77,'2007-02-14','3',5,'Homologação Concluida','../anexo/log/20070214/200702141334[B unimplemented].txt'),
(78,'2007-02-14','1',5,'Homologação Concluida','../anexo/log/20070214/200702141337.txt'),
(79,'2007-02-14','3',5,'Homologação Concluida','../anexo/log/20070214/200702141337[B unimplemented].txt'),
(80,'2007-02-14','1',5,'Homologação Concluida','../anexo/log/20070214/200702141339.txt'),
(81,'2007-02-14','3',5,'Homologação Concluida','../anexo/log/20070214/200702141339[B unimplemented].txt'),
(82,'2007-02-26','3',6,'Alterado Gestor','../anexo/log/20070226/200702262025[B unimplemented].txt'),
(83,'2007-02-26','3',6,'Validado pela TI','../anexo/log/20070226/200702262025[B unimplemented]vt.txt'),
(84,'2007-02-26','3',6,'Alterado Gestor','../anexo/log/20070226/200702262026[B unimplemented].txt'),
(85,'2007-02-26','3',6,'Demanda Suspensa por ANALISTA','../anexo/log/20070226/200702262026[B unimplemented]vt.txt'),
(86,'2007-02-26','3',6,'Alterado Gestor','../anexo/log/20070226/200702262026[B unimplemented].txt'),
(87,'2007-03-05','1',5,'Homologação Concluida','../anexo/log/20070305/200703051805.txt'),
(88,'2007-03-05','3',5,'Homologação Concluida','../anexo/log/20070305/200703051805[B unimplemented].txt'),
(89,'2007-03-05','1',5,'Homologação Concluida','../anexo/log/20070305/200703051834.txt'),
(90,'2007-03-05','3',5,'Homologação Concluida','../anexo/log/20070305/200703051834[B unimplemented].txt'),
(91,'2007-03-06','1',5,'Homologação Concluida','../anexo/log/20070306/200703061102.txt'),
(92,'2007-03-06','3',5,'Homologação Concluida','../anexo/log/20070306/200703061102[B unimplemented].txt'),
(93,'2007-03-06','1',5,'Homologação Concluida','../anexo/log/20070306/200703061103.txt'),
(94,'2007-03-06','3',5,'Homologação Concluida','../anexo/log/20070306/200703061103[B unimplemented].txt'),
(95,'2007-03-06','1',5,'Aceito Pelo Cliente','../anexo/log/20070306/200703061859.txt'),
(96,'2007-03-09','1',5,'Em Produção','../anexo/log/20070309/200703091314.txt'),
(97,'2007-03-09','3',5,'Em Produção','../anexo/log/20070309/200703091314[B unimplemented].txt');

/*Table structure for table `s_funcao_sgd` */

DROP TABLE IF EXISTS `s_funcao_sgd`;

CREATE TABLE `s_funcao_sgd` (
  `nu_seq_funcao_sgd` int(8) NOT NULL auto_increment,
  `no_funcao` varchar(255) NOT NULL default '',
  PRIMARY KEY  (`nu_seq_funcao_sgd`)
) TYPE=MyISAM;

/*Data for the table `s_funcao_sgd` */

insert into `s_funcao_sgd` values 
(1,'Analista de Sistemas'),
(2,'Projetista'),
(3,'Implementadores'),
(4,'Desenvolvedor'),
(5,'DBA');

/*Table structure for table `s_gestor_aplicacao` */

DROP TABLE IF EXISTS `s_gestor_aplicacao`;

CREATE TABLE `s_gestor_aplicacao` (
  `nu_seq_gestor_aplicacao` int(8) NOT NULL auto_increment,
  `nu_seq_aplicacao` int(8) NOT NULL default '0',
  `nu_seq_usuario` int(8) NOT NULL default '0',
  `st_ativo` char(1) NOT NULL default '',
  PRIMARY KEY  (`nu_seq_gestor_aplicacao`)
) TYPE=MyISAM;

/*Data for the table `s_gestor_aplicacao` */

insert into `s_gestor_aplicacao` values 
(1,1,1,'1');

/*Table structure for table `s_grupo` */

DROP TABLE IF EXISTS `s_grupo`;

CREATE TABLE `s_grupo` (
  `nu_seq_grupo` int(8) NOT NULL auto_increment,
  `ds_grupo` varchar(100) NOT NULL default '',
  `dt_expiracao` varchar(16) NOT NULL default '',
  `no_grupo` varchar(100) NOT NULL default '',
  `nu_seq_aplicacao` int(8) NOT NULL default '0',
  PRIMARY KEY  (`nu_seq_grupo`,`no_grupo`)
) TYPE=MyISAM;

/*Data for the table `s_grupo` */

insert into `s_grupo` values 
(1,'cordenação de relacionamento','','sgd_coordenador_relacionamento',1),
(2,'gestor','','sgd_gestor',1),
(3,'cordenação de relatorio','','sgd_coor_relat',1),
(4,'cordenação de fabrica','','sgd_coor_fabric',1),
(5,'gerente de projeto','','sgd_gerente_projeto',1),
(6,'analista de relacionamento','','sgd_analista_relat',1),
(7,'usuario','','sgd_usuario',1),
(8,'USUARIO DE SERVIÇOS','','sgd_user_serv',0),
(9,'ADMINISTRADOR','','sgd_admin',0);

/*Table structure for table `s_recurso_atividade` */

DROP TABLE IF EXISTS `s_recurso_atividade`;

CREATE TABLE `s_recurso_atividade` (
  `nu_seq_atividade` int(8) NOT NULL auto_increment,
  `desc_atividade` varchar(255) NOT NULL default '',
  `nu_seq_fase` int(8) NOT NULL default '0',
  PRIMARY KEY  (`nu_seq_atividade`)
) TYPE=MyISAM;

/*Data for the table `s_recurso_atividade` */

insert into `s_recurso_atividade` values 
(1,'Definição de requesito',8),
(2,'Entrega da Solução',11);

/*Table structure for table `s_recurso_dispensa` */

DROP TABLE IF EXISTS `s_recurso_dispensa`;

CREATE TABLE `s_recurso_dispensa` (
  `nu_seq_dispensa` int(8) NOT NULL auto_increment,
  `st_recurso_dispensa` char(1) NOT NULL default '',
  `nu_seq_recurso` int(8) NOT NULL default '0',
  `dt_ini_dispensa` varchar(16) NOT NULL default '',
  `dt_fim_dispensa` varchar(16) NOT NULL default '',
  `ds_dispensa` varchar(255) default NULL,
  PRIMARY KEY  (`nu_seq_dispensa`)
) TYPE=MyISAM;

/*Data for the table `s_recurso_dispensa` */

/*Table structure for table `s_recurso_feriado` */

DROP TABLE IF EXISTS `s_recurso_feriado`;

CREATE TABLE `s_recurso_feriado` (
  `nu_seq_feriado` int(8) NOT NULL auto_increment,
  `ds_feriado` varchar(100) NOT NULL default '',
  `dt_feriado` varchar(16) NOT NULL default '',
  PRIMARY KEY  (`nu_seq_feriado`)
) TYPE=MyISAM;

/*Data for the table `s_recurso_feriado` */

insert into `s_recurso_feriado` values 
(1,'Confraternização','2007-01-01');

/*Table structure for table `s_recurso_hora` */

DROP TABLE IF EXISTS `s_recurso_hora`;

CREATE TABLE `s_recurso_hora` (
  `nu_seq_hora` int(8) NOT NULL auto_increment,
  `hr_hora_mensal` varchar(100) NOT NULL default '',
  `dt_periodo` varchar(16) NOT NULL default '',
  PRIMARY KEY  (`nu_seq_hora`)
) TYPE=MyISAM;

/*Data for the table `s_recurso_hora` */

insert into `s_recurso_hora` values 
(1,'155','2007-01-18');

/*Table structure for table `s_recurso_projeto` */

DROP TABLE IF EXISTS `s_recurso_projeto`;

CREATE TABLE `s_recurso_projeto` (
  `nu_seq_rec_proj` int(8) NOT NULL auto_increment,
  `nu_seq_recurso_usuario` int(8) NOT NULL default '0',
  `nu_seq_projeto` int(8) NOT NULL default '0',
  `dt_recurso_projeto` varchar(16) NOT NULL default '',
  `hr_recurso_projeto` varchar(10) NOT NULL default '',
  `nu_seq_atividade` int(8) default NULL,
  `nu_seq_hora` int(8) default NULL,
  PRIMARY KEY  (`nu_seq_rec_proj`)
) TYPE=MyISAM;

/*Data for the table `s_recurso_projeto` */

insert into `s_recurso_projeto` values 
(1,2,5,'2007-02-12','5',1,NULL),
(2,2,5,'2007-02-13','6',1,NULL),
(3,2,5,'2007-02-14','5',1,NULL),
(4,2,5,'2007-02-15','7',1,NULL),
(5,2,5,'2007-02-16','4',1,NULL),
(6,2,5,'2007-02-17','2',1,NULL),
(7,2,5,'2007-02-18','5',1,NULL),
(8,2,5,'2007-02-19','7',1,NULL),
(9,2,5,'2007-02-20','3',1,NULL),
(10,2,5,'2007-02-21','4',1,NULL),
(11,2,5,'2007-02-22','4',1,NULL),
(12,2,5,'2007-02-23','3',1,NULL),
(13,2,5,'2007-02-24','3',1,NULL),
(14,2,5,'2007-02-26','2',2,NULL);

/*Table structure for table `s_recurso_tempo` */

DROP TABLE IF EXISTS `s_recurso_tempo`;

CREATE TABLE `s_recurso_tempo` (
  `nu_seq_tempo` int(8) NOT NULL auto_increment,
  `nu_seq_recurso_usuario` int(8) NOT NULL default '0',
  `nu_seq_projeto` int(8) NOT NULL default '0',
  `qt_tempo` varchar(100) NOT NULL default '',
  `qt_tempo_total` varchar(100) NOT NULL default '',
  PRIMARY KEY  (`nu_seq_tempo`)
) TYPE=MyISAM;

/*Data for the table `s_recurso_tempo` */

/*Table structure for table `s_recurso_usuario` */

DROP TABLE IF EXISTS `s_recurso_usuario`;

CREATE TABLE `s_recurso_usuario` (
  `nu_seq_recurso_usuario` int(8) NOT NULL auto_increment,
  `nu_seq_sub_funcao_sgd` int(8) NOT NULL default '0',
  `nu_seq_usuario` int(8) NOT NULL default '0',
  `ds_recurso_usuario` longtext NOT NULL,
  PRIMARY KEY  (`nu_seq_recurso_usuario`)
) TYPE=MyISAM;

/*Data for the table `s_recurso_usuario` */

insert into `s_recurso_usuario` values 
(1,1,2,'Sistemas'),
(2,2,4,'Sistemas');

/*Table structure for table `s_sub_funcao_sgd` */

DROP TABLE IF EXISTS `s_sub_funcao_sgd`;

CREATE TABLE `s_sub_funcao_sgd` (
  `nu_seq_sub_funcao_sgd` int(8) NOT NULL auto_increment,
  `no_sub_funcao_sgd` varchar(155) NOT NULL default '',
  `nu_seq_funcao_sgd` int(8) NOT NULL default '0',
  PRIMARY KEY  (`nu_seq_sub_funcao_sgd`)
) TYPE=MyISAM;

/*Data for the table `s_sub_funcao_sgd` */

insert into `s_sub_funcao_sgd` values 
(1,'Analista de Sistemas',1),
(2,'Projetista',2);

/*Table structure for table `s_usuario_grupo` */

DROP TABLE IF EXISTS `s_usuario_grupo`;

CREATE TABLE `s_usuario_grupo` (
  `nu_seq_usuario_grupo` int(8) NOT NULL auto_increment,
  `nu_seq_grupo` int(8) NOT NULL default '0',
  `nu_seq_usuario` int(8) NOT NULL default '0',
  `st_ativo` char(1) NOT NULL default '',
  PRIMARY KEY  (`nu_seq_usuario_grupo`)
) TYPE=MyISAM;

/*Data for the table `s_usuario_grupo` */

insert into `s_usuario_grupo` values 
(5,5,6,'s'),
(2,6,2,'s'),
(3,2,3,'s'),
(4,5,4,'s'),
(6,1,1,'s'),
(8,4,7,'S'),
(10,1,9,'S'),
(11,1,10,'S'),
(12,5,11,'S'),
(13,5,12,'S');

/*Table structure for table `sistemas` */

DROP TABLE IF EXISTS `sistemas`;

CREATE TABLE `sistemas` (
  `id` int(8) NOT NULL auto_increment,
  `no_sistema` varchar(60) default NULL,
  `nu_seq_gestor_aplicacao` int(12) NOT NULL default '0',
  `co_sistema` varchar(12) NOT NULL default '',
  PRIMARY KEY  (`id`)
) TYPE=MyISAM;

/*Data for the table `sistemas` */

insert into `sistemas` values 
(1,'SISTEMA DE GESTAO DE DEMANDAS',3,'SGD'),
(2,'SISTEMA DE GESTAO DE ARQUIVOS',3,'SDA');

/*Table structure for table `solicita_mudanca` */

DROP TABLE IF EXISTS `solicita_mudanca`;

CREATE TABLE `solicita_mudanca` (
  `id` int(8) NOT NULL auto_increment,
  `id_projeto` int(8) NOT NULL default '0',
  `id_usuario` int(8) default NULL,
  `titulo` varchar(200) default NULL,
  `descricao` varchar(255) default NULL,
  `data` varchar(16) default NULL,
  PRIMARY KEY  (`id`)
) TYPE=MyISAM;

/*Data for the table `solicita_mudanca` */

insert into `solicita_mudanca` values 
(1,2,1,'alteração de corpo','teste teste teste','2007-01-18'),
(2,6,1,'uyr','utr','2007-03-07'),
(3,6,2,'hdfh','dfhfdhfd','2007-03-08');

/*Table structure for table `teams` */

DROP TABLE IF EXISTS `teams`;

CREATE TABLE `teams` (
  `id` int(8) NOT NULL auto_increment,
  `project` int(8) NOT NULL default '0',
  `member` int(8) NOT NULL default '0',
  `published` char(1) NOT NULL default '',
  `authorized` char(1) NOT NULL default '',
  PRIMARY KEY  (`id`)
) TYPE=MyISAM;

/*Data for the table `teams` */

insert into `teams` values 
(1,1,1,'1','0'),
(3,3,0,'1','0'),
(4,3,1,'1','0'),
(5,3,4,'1','0'),
(6,4,3,'1','0'),
(7,4,0,'1','0'),
(11,5,3,'1','0'),
(9,5,0,'1','0'),
(12,5,6,'1','0'),
(13,5,4,'1','0'),
(19,6,3,'1','0'),
(15,6,0,'1','0'),
(16,1,4,'1','0'),
(20,8,6,'1','0');

/*Table structure for table `termo_aceite` */

DROP TABLE IF EXISTS `termo_aceite`;

CREATE TABLE `termo_aceite` (
  `id` int(8) NOT NULL auto_increment,
  `relacionamento` varchar(10) default NULL,
  `comunica` varchar(10) default NULL,
  `alinha` varchar(10) default NULL,
  `solucao` varchar(10) default NULL,
  `prazo` varchar(10) default NULL,
  `performace` varchar(10) default NULL,
  `estabilidade` varchar(10) default NULL,
  `erros` varchar(10) default NULL,
  `atendimento` varchar(10) default NULL,
  `pontualidade` varchar(10) default NULL,
  `ambiente` varchar(10) default NULL,
  `cenario` varchar(10) default NULL,
  `id_projeto` int(8) NOT NULL default '0',
  `id_menber` int(8) default NULL,
  PRIMARY KEY  (`id`)
) TYPE=MyISAM;

/*Data for the table `termo_aceite` */

insert into `termo_aceite` values 
(1,'5','4','3','2','3','5','5','5','5','5','5','5',5,3);
