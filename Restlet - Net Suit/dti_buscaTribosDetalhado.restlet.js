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
	"../../dti_modulos_netsuite/src/Repository/dtiTriboRepository.js",
	"../../dti_modulos_netsuite/src/Service/dtiFuncionarioService.js"

], function (
	search,
	consts,
	dtiUtil,
	CTRepository,
	triboRepository,
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
		var listaTribos = [];
		var resultadoBuscaTribo = triboRepository.buscaTriboRound();

		resultadoBuscaTribo.forEach(function (tribo) {
			listaTribos.push({
				id: tribo.id ? tribo.id : null,
				nome: tribo.nome ? tribo.nome : null,
				alianca: tribo.alianca ? tribo.alianca : null,
				temVisibilidadeDasDispesas: tribo.temVisibilidadeDasDispesas ? tribo.temVisibilidadeDasDispesas : null,
				ehTriboIndireta: tribo.ehTriboIndireta ? tribo.ehTriboIndireta : null,
				nomeTribo: tribo.nomeTribo ? tribo.nomeTribo : null,
			});
		});

		let jsonl = "";
		listaTribos.forEach(function (objeto) {
			jsonl += (JSON.stringify(objeto) + "\n");
		});
		jsonl = jsonl.slice(0, -1);
		return jsonl;
	}

	return {
		get: doGet,
	};
});
