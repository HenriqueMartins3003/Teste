<!--
function ChangeImagem(div,img,cont) {
	var imagem = 'imagem'+div;

	document.getElementById(imagem).src = '../themes/default/'+img+'_over.gif';
	document.getElementById("div"+div).style.display = 'block';

	for (var i = 1; i <= cont; i++) {
		if (imagem != 'imagem'+i) {
			document.getElementById("div"+i).style.display = 'none';
			document.getElementById('imagem'+i).src = document.getElementById('imagem'+i).src.replace('_over','');
		}
	}
}

function enField(valor,form) {
	if (form.name == "form_statusForm") {
		if (valor == '4') form.grgc.disabled = false;
		else form.grgc.disabled = true;
		if (valor == '2') form.sigc.disabled = false;
		else form.sigc.disabled = true;	  
		if (valor == '5') form.anrc.disabled = false;
		else form.anrc.disabled = true;
		if (valor == '3') form.gsgc.disabled = false;
		else form.gsgc.disabled = true;
	}
	else if (form.name == "form_satisfacaoForm") {
		if (valor == '8') form.gsgc.disabled = false;
		else form.gsgc.disabled = true;
		if (valor == '9') form.ungc.disabled = false;
		else form.ungc.disabled = true;
	}
	else if (form.name == "form_comparativoForm") {
		if (valor == '6') {
			form.tmger.disabled = false;
			form.anger.disabled = false;
		} else {
			form.tmger.disabled = true;
			form.anger.disabled = true;			
		}
		if (valor == '10') {
			form.tmanr.disabled = false;
			form.ananr.disabled = false;			
		} else {
			form.tmanr.disabled = true;
			form.ananr.disabled = true;
		}
		if (valor == '15') {
			form.ms.disabled = false;
			form.an.disabled = false;
		} 
		else {
			form.ms.disabled = true;
			form.an.disabled = true;
		}
	}
	else if (form.name == "form_backlogForm") {
		if (valor == '1') form.ungc.disabled = false;
		else form.ungc.disabled = true;
		if (valor == '2') form.sigc.disabled = false;
		else form.sigc.disabled = true;
		if (valor == '3') form.gsgc.disabled = false;
		else form.gsgc.disabled = true;
		if (valor == '4') form.grgc.disabled = false;
		else form.grgc.disabled = true;		
	}
}

function enableField (valor) {
	if (valor == '1') document.getElementById('ung').disabled = false;
	else document.getElementById('ung').disabled = true;
	if (valor == '2') document.getElementById('sig').disabled = false;
	else document.getElementById('sig').disabled = true;
	if (valor == '3') document.getElementById('gsg').disabled = false;
	else document.getElementById('gsg').disabled = true;
	if (valor == '4') document.getElementById('grg').disabled = false;
	else document.getElementById('grg').disabled = true;
	if (valor == '5') document.getElementById('anr').disabled = false;
	else document.getElementById('anr').disabled = true;
}

function MM_findObj(n, d) { //v4.01
	var p,i,x;  if(!d) d=document; if((p=n.indexOf("?"))>0&&parent.frames.length) {
		d=parent.frames[n.substring(p+1)].document; n=n.substring(0,p);}
	if(!(x=d[n])&&d.all) x=d.all[n]; for (i=0;!x&&i<d.forms.length;i++) x=d.forms[i][n];
	for(i=0;!x&&d.layers&&i<d.layers.length;i++) x=MM_findObj(n,d.layers[i].document);
	if(!x && d.getElementById) x=d.getElementById(n); return x;
}

function MM_showHideLayers() { //v6.0
	var i,p,v,obj,args=MM_showHideLayers.arguments;
	for (i=0; i<(args.length-2); i+=3) 
		if ((obj=MM_findObj(args[i]))!=null) { 
			v=args[i+2];
			if (obj.style) { 
				obj=obj.style; v=(v=='show')?'visible':(v=='hide')?'hidden':v; 
			}
			obj.visibility=v; 
		}
}

function validar(form) {

	if (form.name == "form_consultaForm") {
		if (form.unc.value == "0" && form.si.value == "0" && form.gs.value == "0" && form.id_prioridade.value == "0" && form.tipo_demanda.value == "3" && form.id_status.value == "0") {
			alert("É necessário selecionar pelo menos um campo.");
			form.unc.focus();
			return false;
		 }	
		if (form.an.value == "0") {
			alert("Selecione o Ano da Demanda.");
			form.an.focus();
			return false;
		}
	}
	
	if (form.name == "form_estatisticasForm") {

		if (form.op[0].checked && form.ung.value == "0") {
			alert("Selecione uma Unidade.");
			form.ung.focus();
			return false;
		}
		if (form.op[1].checked && form.sig.value == "0") {
			alert("Selecione um Sistema.");
			form.sig.focus();
			return false;
		}
		if (form.op[2].checked && form.gsg.value == "0") {
			alert("Selecione um Gestor.");
			form.gsg.focus();
			return false;
		}
		if (form.op[3].checked && form.grg.value == "0") {
			alert("Selecione um Gerente de Projeto.");
			form.grg.focus();
			return false;
		}
		if (form.op[4].checked == 5 && form.anr.value == "0") {
			alert("Selecione um Analista de Relacionamento.");
			form.anr.focus();
			return false;
		}
		if (form.an.value == "0"){
			alert("Selecione o Ano da Demanda.");
			form.an.focus();
			return false;
		}
		
	}

	if (form.name == "form_statusForm") {
		if (form.an.value == "0") {
			alert("Selecione o Ano da Demanda.");
			form.an.focus();
			return false;
		}
	}
	if (form.name == "form_satisfacaoForm") {
		if (form.an.value == "0") {
			alert("Selecione o Ano da Demanda.");
			form.an.focus();
			return false;
		}
	}
	if (form.name == "form_comparativoForm") {
		if ((form.opc[0].value == 6) && (form.anger.value == "0")) {
			alert("Selecione o Ano do Período.");
			form.anger.focus();
			return false;
		}
		if ((form.opc[0].value == 10) && (form.ananr.value == "0")) {
			alert("Selecione o Ano do Período.");
			form.ananr.focus();
			return false;
		}
		if ((form.opc[0].value == 15) && (form.an.value == "0")) {
			alert("Selecione o Ano do Período.");
			form.an.focus();
			return false;
		}		
	}	
	return true;

/*
	if (form.name == "form_consulta") {
		ano 	   = form.an.value;
		prioridade = form.id_prioridade.value;
		unidade	   = form.un.value;
		gestor 	   = form.gs.value;
		sistema	   = form.si.value;
		status 	   = form.id_status.value;
		tipo_demanda = form.tipo_demanda.value;
		  
		if (ano == "0" && prioridade == "0" && unidade == "0" && gestor == "0" && sistema == "0" && status == "0" && tipo_demanda == "3"){
			alert("É necessário selecionar pelo menos um campo.");
			form.un.focus();
			return false;
		 }	
		 return true;
	}
	
	if (form.name == "form_estatisticas") {
		 var ano = form.an.value;
		 if (ano == "0"){
			alert("Selecione o Ano da Demanda.");
			form.an.focus();
			return (false);
		 }
			var opc  = form_this.op.value;
			var uni  = form_this.ung.value;
			var sis  = form_this.sig.value;
			var ges  = form_this.gsg.value;
			var ger  = form_this.grg.value;
			var arel = form_this.anr.value;
		
		//validacao de radio buttons sem saber quantos sao

		if (ano != "0" && form.op.value == ""){
			alert("Gerar Gráfico Geral.");
			return true;
		}	
		if (form.op[0].value == 1 && uni == "") {
			alert(marcado);
			alert("Selecione uma Unidade.");
			form.ung.focus();
			return false;
		}
		if (marcado == 1 && sis == "0") {
			alert("Selecione um Sistema.");
			form.sig.focus();
			return false;
		}
		if (marcado == 2 && ges == "0") {
			alert("Selecione um Gestor.");
			form.gsg.focus();
			return false;
		 }
		 if (marcado == 3 && ger == "0") {
			 alert("Selecione um Gerente de Projeto.");
			 form.grg.focus();
			 return false;
		 }
		 if (marcado == 4 && arel == "0") {
			 alert("Selecione um Analista de Relacionamento.");
			 form.anr.focus();
			 return false;
		 }
		return true;
	}	
	
	if (form.name == "form_gerencial") {
		mes		   = form.ms.value;
		ano		   = form.an.value;
		prioridade = form.id_prioridade.value;
		unidade	   = form.un.value;
		gestor 	   = form.gs.value;
		sistema    = form.si.value;
		status 	   = form.id_status.value;
		tipo_demanda   = form.tipo_demanda.value;
		relacionamento = form.arel.value;
		sit 	   = form.situacao.value;
		gerente    = form.grprojeto.value;
		  
		if (mes == "0" && ano == "0" && prioridade == "0" && unidade == "0" && gestor == "0" && sistema == "0" && status == "0" && tipo_demanda == "3" && relacionamento == "0" && sit == "20" && gerente == "0"){
			alert("É necessário selecionar pelo menos um campo.");
			form.un.focus();
			return false;
		 }	
		 return true;
	}	
		  
	if (form.name == "form_prioridade") {
	    ano 	= form.an.value;
		sistema = form.sist.value;
		unidade = form.unst.value;
		gestor  = form.gsst.value;
		
		if (ano == "0" && sistema == "0" && unidade == "0" && gestor == "0"){
			alert("É necessário selecionar pelo menos um campo.");
			return false;
		 }
		if (ano == "0" && sistema != "0" && unidade != "0" && gestor == "0"){
			alert("Selecione Somente a Unidade.");
			return false;
		 }
		if (ano == "0" && sistema != "0" && unidade != "0" && gestor != "0"){
			alert("A Unidade Deve Ser Selecionada Sozinha.");
			return false;
		 }
		if (ano == "0" && sistema == "0" && unidade != "0" && gestor != "0"){
			alert("A Unidade Deve Ser Selecionada Sozinha.");
			return false;
		 }
		 return true;
	}
	*/
}
