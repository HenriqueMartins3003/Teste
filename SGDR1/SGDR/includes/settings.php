<?php
#Application name: SGD
#Status page: 2
#Path by root: ../includes/settings.php

# installation type
$installationType = "offline"; //select "offline" or "online"

# select database application
$databaseType = "mysql"; //select "sqlserver", "postgresql" or "mysql"

# database parameters
define('MYSERVER','localhost');
define('MYLOGIN','Henrique');
define('MYPASSWORD','300395');
define('MYDATABASE','Demandas');

# notification method
$notificationMethod = "mail"; //select "mail" or "smtp"

# smtp parameters (only if $notificationMethod == "smtp")
define('SMTPSERVER','');
define('SMTPLOGIN','');
define('SMTPPASSWORD','');

# create folder method
$mkdirMethod = "PHP"; //select "FTP" or "PHP"

# ftp parameters (only if $mkdirMethod == "FTP")
define('FTPSERVER','');
define('FTPLOGIN','');
define('FTPPASSWORD','');

# SGD root according to ftp account (only if $mkdirMethod == "FTP")
$ftpRoot = ""; //no slash at the end

# Invoicing module
$enableInvoicing = "true";

# theme choice
define('THEME','default');

# newsdesk limiter
$newsdesklimit = 1; 

# if 1 the admin logs in his homepage
$adminathome = 0;

# session.trans_sid forced
$trans_sid = "true";

# timezone GMT management
$gmtTimezone = "false";

# language choice
$langDefault = "";

# Mantis bug tracking parameters
// Should bug tracking be enabled?
$enableMantis = "false";

// Mantis installation directory
$pathMantis = "http://localhost/mantis/";  // add slash at the end

# CVS parameters
// Should CVS be enabled?
$enable_cvs = "false";

// Should browsing CVS be limited to project members?
$cvs_protected = "false";

// Define where CVS repositories should be stored
$cvs_root = "D:\cvs"; //no slash at the end

// Who is the owner CVS files?
// Note that this should be user that runs the web server.
// Most *nix systems use "httpd" or "nobody"
$cvs_owner = "httpd";

// CVS related commands
$cvs_co = "/usr/bin/co";
$cvs_rlog = "/usr/bin/rlog";
$cvs_cmd = "/usr/bin/cvs";

# https related parameters
$pathToOpenssl = "/usr/bin/openssl";

# login method, set to "CRYPT" in order CVS authentication to work (if CVS support is enabled)
$loginMethod = "CRYPT"; //select "MD5", "CRYPT", or "PLAIN"

# enable LDAP
$useLDAP = "false";
$configLDAP[ldapserver] = "your.ldap.server.address";
$configLDAP[searchroot] = "ou=People, ou=Intranet, dc=YourCompany, dc=com";

# htaccess parameters
$htaccessAuth = "false";
$fullPath = "/usr/local/apache/htdocs/SGD/files"; //no slash at the end

# file management parameters
$fileManagement = "true";
$maxFileSize = 51200; //bytes limit for upload
$root = "http://localhost:8080/SGDR"; //no slash at the end

# security issue to disallow php files upload
$allowPhp = "false";

# project site creation
$sitePublish = "true";

# enable update checker
$updateChecker = "false";

# e-mail notifications
$notifications = "true";

# show peer review area
$peerReview = "true";

# show items for home
$showHomeBookmarks =  "true";
$showHomeProjects =  "true";
$showHomeTasks =  "true";
$showHomeDiscussions =  "true";
$showHomeReports =  "true";
$showHomeNotes =  "true";
$showHomeNewsdesk =  "true";

# security issue to disallow auto-login from external link
$forcedLogin = "";

# table prefix
$tablePrefix = "";

# database tables


$tableCollab["calendar"] = "calendar";
$tableCollab["logs"] = "logs";
$tableCollab["members"] = "members";
$tableCollab["organizations"] = "organizations";
$tableCollab["fases"] = "fases";
$tableCollab["fase_pedente"] = "fase_pendente";
$tableCollab["projects"] = "projects";
$tableCollab["projects_corretiva"] = "projects_corretiva";
$tableCollab["teams"] = "teams";
$tableCollab["solicita_mudanca"] = "solicita_mudanca";
$tableCollab["services"] = "services";
$tableCollab["ata_anexo"] = "ata_anexo";
$tableCollab["ata_reuniao"] = "ata_reuniao";
$tableCollab["sistema"] = "sistemas";
$tableCollab["termo_aceite"] = "termo_aceite";
$tableCollab["calender_reuniao"] = "calender_reuniao";
$tableCollab["control"] = "s_control_in";
$tableCollab["s_usuario_grupo"] = "s_usuario_grupo";
$tableCollab["s_grupo"] = "s_grupo";
$tableCollab["s_funcao_sgd"] = "s_funcao_sgd";
$tableCollab["s_sub_funcao_sgd"] = "s_sub_funcao_sgd";
$tableCollab["s_recurso_usuario"] = "s_recurso_usuario";
$tableCollab["s_recurso_tempo"] = "s_recurso_tempo";
$tableCollab["s_recurso_projeto"] = "s_recurso_projeto";
$tableCollab["s_recurso_atividade"] = "s_recurso_atividade";
$tableCollab["s_recurso_hora"] = "s_recurso_hora";
$tableCollab["s_recurso_dispensa"] = "s_recurso_dispensa";
$tableCollab["s_recurso_feriado"] = "s_recurso_feriado";
$tableCollab["s_recurso_usuario"] = "s_recurso_usuario";

# SGD version
$version = "2.5";

# demo mode parameters
$demoMode = "false";
$urlContact = "http://www.sourceforge.net/projects/SGD";

# Gantt graphs
$activeJpgraph = "true";

# developement options in footer
$footerDev = "false";

# filter to see only logged user clients (in team / owner)
$clientsFilter = "false";

# filter to see only logged user projects (in team / owner)
$projectsFilter = "false";

# Enable help center support requests, values "true" or "false"
$enableHelpSupport = "true";

# Return email address given for clients to respond too.
$supportEmail = "email@yourdomain.com";

# Support Type, either team or admin. If team is selected a notification will be sent to everyone in the team when a new request is added
$supportType = "team";

# enable the redirection to the last visited page, EXPERIMENTAL DO NOT USE IT
$lastvisitedpage = "false";

# html header parameters
$setDoctype = "<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.01 Transitional//EN\">";
$setTitle = "SGD";
$setDescription = "Groupware module. Manage web projects with team collaboration, users management, tasks and projects tracking, files approval tracking, project sites clients access, customer relationship management (Php / Mysql, PostgreSQL or Sql Server).";
$setKeywords = "SGD, SGD.com, Sourceforge, management, web, projects, tasks, organizations, reports, Php, MySql, Sql Server, mssql, Microsoft Sql Server, PostgreSQL, module, application, module, file management, project site, team collaboration, free, crm, CRM, cutomer relationship management, workflow, workgroup";
?>