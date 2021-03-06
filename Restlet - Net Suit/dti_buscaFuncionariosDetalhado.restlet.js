/**
 * @NApiVersion 2.x
 * @NScriptType Restlet
 * @NModuleScope Public
 */
define([
	"N/search",
	"../../dti_modulos_netsuite/src/dti_constantes.js",
	"../../dti_modulos_netsuite/src/dti_util.js",
	"../../dti_modulos_netsuite/src/Repository_dtiContratoDeTrabalho.js",
	"../../dti_modulos_netsuite/src/Service/dtiFuncionarioService.js"

], function (
	search,
	consts,
	dtiUtil,
	CTRepository,
	funcionarioService
) {
	/**
	 * Function called upon sending a GET request to the RESTlet.
	 *
	 * @param {Object} requestParams - Parameters from HTTP request URL; parameters will be passed into function as an Object (for all supported content types)
	 * @returns {string | Object} HTTP response body; return string when request Content-Type is 'text/plain'; return Object when request Content-Type is 'application/json'
	 * @since 2015.1
	 */
	function doGet(requestParams) {
		var listaFuncionarios = [];
		var resultadoFuncionarios = CTRepository.buscaFuncionariosComCTAtivo();

		resultadoFuncionarios.forEach(function (funcionario) {
			listaFuncionarios.push({
				nome: funcionarioService.retornaNome(funcionario),
				primeiroNome: funcionario.primeiroNome ? funcionario.primeiroNome : null,
				nomeDoMeio: funcionario.nomeDoMeio ? funcionario.nomeDoMeio : null,
				ultimoNome: funcionario.ultimoNome ? funcionario.ultimoNome : null,
				nomeSocial: funcionario.nomeSocial ? funcionario.nomeSocial : null,
				id: funcionario.id ? funcionario.id : null,
				idTribo: funcionario.idTribo ? funcionario.idTribo : null,
				idTriboAnterior: funcionario.idTriboAnterior ? funcionario.idTriboAnterior : null,
				dataTransferencia: funcionario.dataTransferencia ? funcionario.dataTransferĂȘncia : null,
				idResponsavelMudanca: funcionario.idResponsavelMudanca ? funcionario.idResponsavelMudanca : null,
				cpf: funcionario.cpf ? funcionario.cpf : null,
				idAtivo: funcionario.idAtivo ? funcionario.idAtivo : null,
				idCalendario: funcionario.idCalendario ? funcionario.idCalendario : null,
				telefone: funcionario.telefone ? funcionario.telefone : null,
				email: funcionario.email ? funcionario.email : null,
				idServico: funcionario.idServico ? funcionario.idServico : null,
				emailAlternativo: funcionario.emailAlternativo ? funcionario.emailAlternativo : null,
				idAdmissao: funcionario.idAdmissao ? funcionario.idAdmissao : null,
				idMoeda: funcionario.idMoeda ? funcionario.idMoeda : null,
				idSexo: funcionario.idSexo ? funcionario.idSexo : null,
				idSupervisor: funcionario.idSupervisor ? funcionario.idSupervisor : null,
				idSubsidiaria: funcionario.idSubsidiaria ? funcionario.idSubsidiaria : null,
				idDocumentacaoAdmissao: funcionario.idDocumentacaoAdmissao ? funcionario.idDocumentacaoAdmissao : null,
				idInstituicaoDeEnsino: funcionario.idInstituicaoDeEnsino ? funcionario.idInstituicaoDeEnsino : null,
				pcd: funcionario.pcd ? funcionario.pcd : null,
				dataNascimento: funcionario.dataNascimento ? funcionario.dataNascimento : null,

			});
		});

		let jsonl = "";
		listaFuncionarios.forEach(function (objeto) {
			jsonl += (JSON.stringify(objeto) + "\n");
		});
		jsonl = jsonl.slice(0, -1);
		return jsonl;
	}

	return {
		get: doGet,
	};
});
