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
		var listaContratos = [];
		var resultadoContratos = CTRepository.buscaTodosOsContratosVigentes();

		resultadoContratos.forEach(function (contrato) {
			listaContratos.push({
				id: contrato.funcionario.id ? contrato.funcionario.id : null,
				dataInicio: contrato.dataInicio ? contrato.dataInicio : null,
				dataFim: contrato.dataFim ? contrato.dataFim : null,
				tipo: contrato.tipo ? contrato.tipo : null,
				horario: contrato.horario ? contrato.horario : null,
				ctps: contrato.ctps ? contrato.ctps : null,
				tempoDti: contrato.tempoDti ? contrato.tempoDti : null,
			});
		});

		let jsonl = "";
		listaContratos.forEach(function (objeto) {
			jsonl += (JSON.stringify(objeto) + "\n");
		});
		jsonl = jsonl.slice(0, -1);
		return jsonl;
	}

	return {
		get: doGet,
	};
});
