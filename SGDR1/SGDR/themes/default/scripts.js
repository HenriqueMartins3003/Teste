// JavaScript Document

//
function filtro(campo,valor){

window.location.href=""+campo+"?fillter=true&fill="+valor;

}

function TrocaList(ListOrigem,ListDestino) 
{
//var i;
 document.addsup.control.value = ListOrigem;
//l =  ListOrigem;
//ListDestino = ListOrigem;
//alert("legal" + ListOrigem  );
/*
	for (i = 0; i < ListOrigem.options.length ; i++)
	{
		if (ListOrigem.options[i].selected == true)
		{
		var Op = document.createElement("OPTION");
		Op.text = ListOrigem.options[i].text;
		Op.value = ListOrigem.options[i].value;
		ListDestino.options.add(Op);
		ListOrigem.options.remove(i);
		i--;
		}
	}
*/
}


function scrollver(){
	//alert('desce!');
	window.scrollBy(0,10000);
}

function PressEnter(campo,e){
  var keynum;

 if(window.event) // IE
    keynum = window.event.keyCode;
  else if(e.keyCode) // Netscape/Firefox/Opera
    keynum = e.keyCode;
  if (keynum == 13){
   filtro(campo,e);
    
  }
}

function ContaCaracteres(dados,conta,mostra,valor){
	var intCaracteres;
	
	intLength = document.getElementById(dados).value.length;
	
  	//intCaracteres = 200 - document.form1.textarea.value.length;
   	intCaracteres = parseInt(valor) - parseInt(intLength);

   	if (intCaracteres > 0) {
    	//document.form1.textconta.value = intCaracteres;
	  	document.getElementById(conta).value = intCaracteres;
     	//sBann.innerHTML = intCaracteres;
	 	document.getElementById(mostra).innerHTML = intCaracteres;
	 	return true;
   	}
   	else {
    	//document.form1.textconta.value = 0;
	 	document.getElementById(conta).value = 0 ;
      	//document.form1.textarea.value = document.form1.textarea.value.substr(0,200);
      	document.getElementById(dados).value = document.getElementById(dados).value.substr(0,valor); 
	   	sBann.innerHTML = 0 ;
	  	return false;
   }
}
function Validar(){
   if (ContaCaracteres()){
      alert('Enviado com Sucesso');
   }
   else{
      alert("Número de caracteres do comentário maior que 200.");
   }
}

//
function Valida(VT){
     var titulo = VT.pn.value;
     var anl = VT.select_analista.value;
	if(titulo == ''){
		alert('O campo Título deve ser preenchido!!');
       	VT.pn.focus();
       return false;
	}
	if(anl=='0'){
	alert('Informe Analista de Relacionamento!');
	return false;
	}
 return true;
}

//

function verifica_campo(erro){
	var titulo = document.addsupport.tit.value;
	var arquivo = document.addsupport.mes.value
	//alert('ok');
	if(titulo=="" && arquivo==""){
	alert('Preencha todos os campos!');
	return false;
	}else{ if(titulo=="" ){
	       alert('Preencha o campo Titulo!');
	       return false;
	       }
		   if(arquivo=="" ){
	       alert('Preencha o campo Arquivo!');
	       return false;
	       }else{
			    return true; 
			    }
         }
	
	
	}

//
function updateorg(valor,url){
	
	window.location.href=''+url+'&org='+valor+''; 
	}

function urlrede(valor,url){
	//alert('fez');
	window.location.href=''+url+'&'+valor+''; 
	}


// Verifica se a Data digitada é válida
function isValidData(vfield, vfieldName,valor)
{
var diaStr, mesStr, anoStr;
var diaInt, mesInt, anoInt;
var tam, sep1, sep2, verAno;
var ele = document.getElementById(valor);

tam = vfield.value.length;
dem = vfield;
sep1 = parseInt(vfield.value.indexOf("-", 0));

if(tam>0){
if (sep1<0)
{
ele.focus();
alert("A Data digitada deve ter o seguinte formato: DD-MM-AAAA!!");

return false;
}

sep2 = parseInt(vfield.value.indexOf("-", sep1+1))

if (sep2<5)
{
ele.focus();
alert("A Data digitada deve ter o seguinte formato: DD-MM-AAAA !");

return false;
}

verAno = tam-sep2;

if(verAno < 5 )
{
ele.focus();
alert("As datas devem ser preenchidas utilizando 4 dígitos para informar o Ano (ex.: DD-MM-AAAA)!");
;
return false;
}

diaStr = vfield.value.substring(0, sep1);

if(diaStr.substring(0, 1) == "0")
diaStr = diaStr.substring(1, 2);

if (isValidNumberValue(diaStr, vfieldName))
{
mesStr = vfield.value.substring(sep1+1, sep2); 

if(mesStr.substring(0, 1) == "0")
mesStr = mesStr.substring(1, 2);

if (isValidNumberValue(mesStr, vfieldName))
{
anoStr = vfield.value.substring(sep2+1, tam);

if (isValidNumberValue(anoStr, vfieldName))
{
diaInt = parseInt(diaStr);
mesInt = parseInt(mesStr);
anoInt = parseInt(anoStr);

if ((diaInt <= 0) || (diaInt > 31))
{
alert("O dia informado não é válido!");
return false;
}

if ((mesInt <= 0) || (mesInt > 12))
{
alert("O mês informado não é válido!");
return false;
}

if ((mesInt == 4) || (mesInt == 6) || (mesInt == 9) || (mesInt == 11))
{
if( diaInt > 30)
{
alert("O mês informado não possui mais de 30 dias!");
return false;
}
}

if (mesInt == 2)
{
if ((anoInt % 4 == 0) && ( (anoInt % 100 != 0) || (anoInt % 400 == 0)))
{
if (diaInt > 29)
{
alert("O mês informado não possui mais de 29 dias!");
return false;
}
}
else
{
if(diaInt > 28)
{
alert("O mês informado não possui mais de 28 dias!");
return false;
}
}
return true;
} 
return true;
}
else
return false;
}
else
return false;
}
else
return false;
}

// Verifica se somente números foram digitados no campo;
function isValidNumberValue (objTextControl, strFieldName) 
{
var strValidNumber = "1234567890";

for (nCount=0; nCount < objTextControl.length; nCount++) 
{
strTempChar=objTextControl.substring(nCount,nCount+1);
if ( strValidNumber.indexOf(strTempChar,0)==-1) 
{
alert("O campo " + strFieldName + " deve conter somente números!");
return false; 
}
} 

return true;

} //if tam


}
//

function isValid( objTextControl, strFieldName) 
{
var nRet = true;
var strValidNumber="-1234567890.,";
if( isValidString( objTextControl, strFieldName))
{
for (nCount=0; nCount < objTextControl.value.length; nCount++) 
{
strTempChar=objTextControl.value.substring(nCount,nCount+1);
if ( strValidNumber.indexOf(strTempChar,0)==-1) 
{
alert("O campo " + strFieldName + " deve ser numérico!")
objTextControl.focus()
return false;
}
} 
}
else
{
return false;
}
return(nRet);
}



function completa_data(form,campo){
campot = eval("document."+form+"."+campo);
	if(campot.value.length ==2){
	campot.value = campot.value+"-";
	}
		if(campot.value.length ==5){
		campot.value = campot.value+"-";
		}
}
		
		//coloca foco no campo informado
		function foco_campo(campo){
			var co = document.getElementById(campo);
			co.focus();
			}
			
		//ALTERAÇÃO 05-08-2006
		function mostra_campo(val,id,chek){
			var valor = document.getElementById("campofile").value;
						
			if (document.getElementById("check").checked==true){
				
				if(document.getElementById("select").value==0){
					alert('Selecione o Sistema!');
					document.getElementById("checkbox").disabled=true;
					document.getElementById("chec").disabled=true;
				}
					
				if(valor==0){
					document.getElementById(val).value = 1;
				}
			}

			if(document.getElementById("check").checked==false){
				document.getElementById("checkbox").disabled=false;
				document.getElementById("chec").disabled=false;
				
				if(valor==1){
					document.getElementById(val).value = 0;
				}
				
			}
		}
		
		function mostra_imagem(valor,id){
			if(valor==1){
			document.getElementById(id).style.display='';
			}
		}
		
		
		function trocaImg(foto,id){
		document.getElementById(id).src='../themes/default/'+foto;
		
		}
		
		function mostra(i,id,idv){
		
		document.getElementById(id).style.display='';
			if(idv!="0"){
			document.getElementById(idv).style.display='';
			}
		
		trocaImg('btn_subtrai.gif',i)
		}
		function fecha(i,id,idv){
		
		document.getElementById(id).style.display='none';
			if(idv!="0"){
			document.getElementById(idv).style.display='none';
			}
			
		trocaImg('btn_soma.gif',i)	
		}
		function verif(i,campo,id,idv){
		//mosindent
				
	    var valor = document.getElementById(""+campo+"").value;
		//var valor =  document.getElementById(campo).value;
		
		//alert("msotra"+valor);
			
		   
			if(valor > 0){
			
			fecha(i,id,idv);
			document.getElementById(campo).value = 0;
			}else{
			mostra(i,id,idv);
			document.getElementById(campo).value = 1;
			}
		//scrollver();
		setTimeout('scrollver()', 20);
		}
		

		//
		function verif2(i,campo,id,idv,val){
			var valor = document.getElementById(campo).value;
			//var cont = document.getElementById(val).value;
			var cont = val ;
			var contidv = idv ;
			var subid = id;
			//alert("teste--> Campo:"+" i :"+i + +campo+" id:"+id+" idv :"+idv+ " val: "+val);
			if(valor > 0){
				//alert("teste--> Campo:"+" i :"+i + +campo+" id:"+id+" idv :"+idv+ " val: "+val);
				for(var z = 0 ; z < cont ; z++){
				//var idvv = "ativg"+z ;
				
				//fecha(i,id,idv);
				if(contidv < 1){
				fecha(i,id+z,idv);
				}else{
					var contusu = document.getElementById("contusus"+subid.substring(4)).value;
					var us = document.getElementById("usufuso"+subid.substring(4)+z).value;
					var quantatv = document.getElementById("contatv"+us).value;
					//alert("idv e maior que 1 :"+ subid.substring(4) +" cont:"+contusu+ " id usuario:"+us + "qtd ativi: "+quantatv );
						//pega atividade a apartir do id do usuario contatv+us
						
						for(var j = 0; j < quantatv; j++){
							fecha(i,"ativg"+us+j,'0');
							//alert("ativg"+us+j);
							}
					fecha(i,id+z,'0');
					}
				
				}
			document.getElementById(campo).value = 0;
			}else{
				//alert("simteste--> Campo: ,i: "+i + ",campo: "+campo+" ,id: "+id+" ,idv :"+idv+ " ,val: "+val);
				for(var z = 0 ; z < cont ; z++){
					
					//if(z=0){
						//alert(id+'0');
						//}else{
						//alert(id+z);
							//}
				if(contidv < 1){			
				mostra(i,id+z,idv);
				}else{
					mostra(i,id+z,'0');
					}
				
				}
			document.getElementById(campo).value = 1;
			}
		
		//scrollver();
		setTimeout('scrollver()', 20);
		}
		//

		function checkin(campo){
			var valor = document.getElementById(campo).value;
			if(valor > 0){
			document.getElementById(campo).value = 0;
			}else{
			document.getElementById(campo).value = 1;
			}
			return true;
		
		}
		
		//ALTERAÇÃO 05-08-2006
		function desabilita(id,campo){
			var valor = document.getElementById(campo).value;
			
			if(valor > 0){
			document.getElementById(id).disabled='' ;
			document.getElementById(campo).value = 0;
			document.getElementById("check").disabled=false;
			document.getElementById("chec").disabled=false;
			
			}else{
			
			document.getElementById(id).disabled='true' ;
			document.getElementById(campo).value = 1;
			document.getElementById("check").disabled=true;
			document.getElementById("chec").disabled=true;
			}
				
		} 
	
		//ALTERAÇÃO 05-08-2006
		function desabilita2(id,campo){
		var valor = document.getElementById(campo).value;
		
			if(valor > 0){
			document.getElementById(id).disabled='' ;
			document.getElementById(campo).value = 0;
			document.getElementById("check").disabled=false;
			document.getElementById("checkbox").disabled=false;
			
			} else {
			document.getElementById(id).disabled='true' ;
			document.getElementById(campo).value = 1;
			document.getElementById("check").disabled=true;
			document.getElementById("checkbox").disabled=true;
			}
					
		}	
	

	function janelaver(ver,arquivo,nome,wt,ht){
		//window.open(arquivo,nome,'"toolbar,scrollbars=yes,width='+wt +' , height='+ht +'"');
if(document.form1.check_termo.checked==true){
//alert('ver='+ver);
window.open(arquivo,nome,'"toolbar,scrollbars=no,width='+wt +' , height='+ht +'"');
}else{
window.open('termoano.php',nome,'"toolbar,scrollbars=no,width=300 , height=50"');
}		
	}

	function janela(arquivo,nome,wt,ht){
		window.open(arquivo,nome,'"toolbar,scrollbars=no,width='+wt +' , height='+ht +'"');
		
	}
	//
	function janelada(arquivo,nome,wt,ht){
		window.open(arquivo,nome,'"toolbar,scrollbars=no,width='+wt +' , height='+ht +'"');
		
	}
	//
	function onjanela(arquivo,nome,wt,ht,ct){
		//var data_prop1 = document.form1.text_pro.value;
		//var data_prop2 = document.form1.text_pro_dfimp.value;
		//var data_pror1 = document.form1.text_pro_dinir.value;
		//var data_pror2 = document.form1.text_pro_dfimr.value;
		
		var c = ct;
		
		if(c == '4'){
		janela(arquivo,nome,wt,ht);
		}
		if(c == '3'){
		//alert("na!");
		
		}
		
	}
	//
	function dajanela(arquivo,nome,wt,ht,ct){
		
		var c = ct;
		
		if((c == '2') || (c == '11') || (c == '12')){
		//janela(arquivo,nome,wt,ht);
		janelada(arquivo+"&tipos="+nome,nome,wt,ht,"no");
		}else{}
		
	}
	//
	
	
//Verifica se a data1 é maior ou igual que a data 2
function datamaiorigual(dt1,dt2)
{
var hoje = new Date();
var ano = hoje.getYear();
if(ano >= 50 && ano <= 99)
ano = 1900 + ano
else
ano = 2000 + ano;

var pos1 = dt1.indexOf("-",0)
var dd = dt1.substring(0,pos1)
pos2 = dt1.indexOf("-", pos1 + 1)
var mm = dt1.substring(pos1 + 1,pos2)
var aa = dt1.substring(pos2 + 1,10)
if(aa.length < 4)
if(ano > 1999)
aa = (2000 + parseInt(aa,10))
else
aa = (1900 + parseInt(aa,10));
var data1 = new Date(parseInt(aa,10),parseInt(mm,10) - 1, parseInt(dd,10));
var pos1 = dt2.indexOf("-",0)
var dd = dt2.substring(0,pos1)
pos2 = dt2.indexOf("-", pos1 + 1)
var mm = dt2.substring(pos1 + 1,pos2)
var aa = dt2.substring(pos2 + 1,10)
if(aa.length < 4)
if(ano > 80 && ano <= 99)
aa = (1900 + parseInt(aa,10))
else
aa = (2000 + parseInt(aa,10));
var data2 = new Date(parseInt(aa,10),parseInt(mm,10) - 1,parseInt(dd,10));

if(data1 > data2)
return true; 
else
return false;
}

// fim verifica data 
	
	function verifica(){
		var data_plap1 = document.form1.text_fase.value;
		var data_plap2 = document.form1.text_fase_dfimp.value;
		var data_plar1 = document.form1.text_fase_dinir.value;
		var data_plar2 = document.form1.text_fase_dfimr.value;
		
		var data_prop1 = document.form1.text_pro.value;
		var data_prop2 = document.form1.text_pro_dfimp.value;
		var data_pror1 = document.form1.text_pro_dinir.value;
		var data_pror2 = document.form1.text_pro_dfimr.value;
		
		var data_denp1 = document.form1.text_den.value;
		var data_denp2 = document.form1.text_den_dfimp.value;
		var data_denr1 = document.form1.text_den_dinir.value;
		var data_denr2 = document.form1.text_den_dfimr.value;
		
		var data_tesp1 = document.form1.text_tes.value;
		var data_tesp2 = document.form1.text_tes_dfimp.value;
		var data_tesr1 = document.form1.text_tes_dinir.value;
		var data_tesr2 = document.form1.text_tes_dfimr.value;
		
		var data_capp1 = document.form1.text_cap.value;
		var data_capp2 = document.form1.text_cap_dfimp.value;
		var data_capr1 = document.form1.text_cap_dinir.value;
		var data_capr2 = document.form1.text_cap_dfimr.value;
		 
		var data_impp1 = document.form1.text_imp.value;
		var data_impp2 = document.form1.text_imp_dfimp.value;
		var data_impr1 = document.form1.text_imp_dinir.value;
		var data_impr2 = document.form1.text_imp_dfimr.value;
		 
		 //Planejamento e planejamento
		// if(datamaiorigual(data_plap1,data_impp2)==true){
		 if((data_plap1== "") && (data_impp2== "")){
			alert('Informe a data do Planejamento e Implantação! ');
			return false;
		 } 	
		 
		
		 
		 //Planejamento
		 if(data_plap1== "" || data_plap2== "") {
			alert('Informe a data do Planejamento ! ');
			return false;
		 }else{
				/*Verifica se data maior e menor*/
				//if(datamaiorigual(data_plap1,data_impp2)==true){ final
			   if(datamaiorigual(data_plap1,data_plap2)==true){
				//if(data_plap1 > data_plap2) {
				
				alert('A data inicio e maior que a data fim do Planejamento em Planejado ! ');
				document.form1.text_fase_dfimp.focus();
				return false;
				}	
			 				 
			 }	
		 
			/*Verifica se data maior e menor*/
			if(datamaiorigual(data_plar1,data_plar2)==true){
			//if(data_plar1 > data_plar2) {
			alert('A data inicio e maior que a data fim do Planejamento em Realizado ! ');
			return false;
			}	
		  
			/*Verifica se data maior e menor processo*/
			if(datamaiorigual(data_prop1, data_prop2)==true){
			//if(data_prop1 > data_prop2) {
			alert('A data inicio e maior que a data fim do Requisito em Planejado ! ');
			document.form1.text_pro_dfimp.focus();
			return false;
			}	
			/*Verifica se data maior e menor processo*/
			if(datamaiorigual(data_pror1,data_pror2)==true){
			//if(data_pror1 > data_pror2) {
			alert('A data inicio e maior que a data fim do Requisito em Realizado ! ');
			document.form1.text_pro_dfimp.focus();
			return false;
			}	
			
			/*Verifica se data maior e menor desenvolvimento*/
			if(datamaiorigual(data_denp1,data_denp2)==true){
			//if(data_denp1 > data_denp2) {
			alert('A data inicio e maior que a data fim do Desenvolvimento em Planejado ! ');
			document.form1.text_den_dfimp.focus();
			return false;
			}	
			/*Verifica se data maior e menor desenvolvimento*/
			if(datamaiorigual(data_denr1,data_denr2)==true){
			//if(data_denr1 > data_denr2) {
			alert('A data inicio e maior que a data fim do Desenvolvimento em Realizado ! ');
			document.form1.text_den_dfimr.focus();
			return false;
			}	
			
			/*Verifica se data maior e menor teste*/
			if(datamaiorigual(data_tesp1,data_tesp2)==true){
			//if(data_tesp1 > data_tesp2) {
			alert('A data inicio e maior que a data fim do Teste em Planejado ! ');
			document.form1.text_tes_dfimp.focus();
			return false;
			}	
			/*Verifica se data maior e menor teste*/
			if(datamaiorigual(data_tesr1 ,data_tesr2)==true){
			//if(data_tesr1 > data_tesr2) {
			alert('A data inicio e maior que a data fim do Teste em Realizado ! ');
			document.form1.text_tes_dfimr.focus();
			return false;
			}	
			
			/*Verifica se data maior e menor treinamento*/
			if(datamaiorigual(data_capp1 ,data_capp2)==true){
			//if(data_capp1 > data_capp2) {
			alert('A data inicio e maior que a data fim do Treinamento em Planejado ! ');
			document.form1.text_cap_dfimp.focus();
			return false;
			}	
			
			 //Implantação
		 if(data_impp1== "" || data_impp2== "") {
			alert('Informe a data de Implantação ! ');
			return false;
		 }else{
				/*Verifica se data maior e menor*/
				if(datamaiorigual(data_impp1,data_impp2)==true){
				//if(data_impp1 > data_impp2) {
				alert('A data inicio é maior que a data fim da Implantação em Planejado ! '+data_impp1 +'--'+data_impp2+'');
				document.form1.text_imp_dfimp.focus();
				return false;
				}	
			 			 
			 }	
		
		//data_plap1 <= data_impp2
		if(datamaiorigual(data_plap1,data_impp2)==false){
		
		//alert('Registrado com Sucesso!');
		//return true;		
		document.form1.action="home.php?addfase=ok";
		document.form1.submit();
		return false;
		}else{ 
		alert('data implantação menor que Planejamento!!');
		return false;
		}
		
	}
	

//INI ENCAMINHADORES AJAX
 
function popupform(myform, windowname,widt,heig){
	var wid = widt;
	if(wid > 0){
		wid = widt;  
	}else{
		wid ="610"; 
	}
		if(heig > 0){
	   	hei = heig;  
    	}else{
    	hei = "450";
    	}

	if(myform.gsst.value==""){
	alert("Selecione Gestor!");	
	return false;
	}else{
	var novajanela = window.open(windowname+"?gsst="+myform.gsst.value,"windowname", 'height='+hei+',width='+wid+',toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=no');
	 novajanela.moveTo(25,30);
	 novajanela.focus();
	
	//myform.target=windowname;
	
	
	return true;
	}


}


function Dados1(value) {
	

	var gest2 = new Dados('gsst','gestoresAjax.php','opcoes',value,"não encontrado",'Gestores:','');

   }

 function Dados3(value) {
	
	var gest = new Dados('gsst','gestoresAjax2.php','opcoes',value,"não encontrado",'gestores','');
	
   }  		
   

function Dadosz(value) {
 
 
 sis = new Dados('sist','sistemas.php','opcoes2',value,'Sistema não encontrado','Sistemas','');

}
  
  function Dados4(value) {

	var unis = new Dados('uni','unidades.php','opcoes3',value,'não encontrado','unidade','');
}

function Dados5(value) {
	
	var ger = new Dados('grp','gerentes.php','opcoes4',value,"não encontrado",'Gerentes de projeto:','');
	
}


function Dados6(value) {
	
	
	var anali = new Dados('anl','analistas.php','opcoes5',value,"não encontrado",'Analista de Relacionamento:','');
	
	
 }

 
 function Dados7(value) {
	
	var gest2 = new Dados('gsst','gestoresAjax3.php','opcoes',value,"não encontrado",'Gestores:','');

 }  

//

//ini formalt.php

function Dadosu(valor){
   var ok = new Dados(valor,'sisformalt.php','sis',valor,'Selecione o Sistema:','Sistema não encotrado','1') ;
}
 
   //
   
function enableField(valor) {

  if (valor == '1') document.getElementById('sisgs').disabled = false;
  else document.getElementById('sisgs').disabled = true;
  if (valor == '1') document.getElementById('nosis2').disabled = false;
  else document.getElementById('nosis2').disabled = true;
  if (valor == '1') document.getElementById('sisgs2').disabled = true;
  else document.getElementById('sisgs2').disabled = false;
  //if (valor == '1') document.getElementById('opcoes').disabled = true;
 // else document.getElementById('opcoes').disabled = false;
  
}
 // fim formalt.php


//FIM ENCAMINHADORES AJAX