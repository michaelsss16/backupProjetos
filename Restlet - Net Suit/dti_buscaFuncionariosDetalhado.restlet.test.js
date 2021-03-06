const { loadSuiteScriptModule, NSearch } = require("../../../dti_netsumo");
const Constantes = require("../../../mocks/modulos/consts");

const consts = new Constantes();
const ScriptBuscaFuncionariosDetalhado = loadSuiteScriptModule("../RESTLet_Script/Funcionarios/dti_buscaFuncionariosDetalhado.restlet.js", true);

let nSearch;
let dtiUtil;
let CTRepository;
let funcionarioService;

let script;

beforeEach(() => {
	nSearch = new NSearch();
	dtiUtil = {
		criaNewDatePorString: jest.fn(),
	}; //fim dtiutil
	dtiUtil.criaNewDatePorString.mockImplementation((data) => {
		var dataComSplit = data.split("/");

		var dia = 0;
		var mes = 0;
		var ano = 0;

		dia = parseInt(dataComSplit[0], 10);
		mes = parseInt(dataComSplit[1], 10) - 1;
		ano = parseInt(dataComSplit[2], 10);

		return (new Date(ano, mes, dia, 0, 0, 0, 0));
	});// fim dtiUtil.criadatastring.makeimplementation

	CTRepository = {
		buscaFuncionariosComCTAtivo: jest.fn(),
	};

	funcionarioService = {
		retornaNome: jest.fn(),
	};

	script = ScriptBuscaFuncionariosDetalhado({
		"N/search": nSearch,
		"../../dti_modulos_netsuite/src/dti_constantes.js": consts,
		"../../dti_modulos_netsuite/src/dti_util.js": dtiUtil,
		"../../dti_modulos_netsuite/src/Repository_dtiContratoDeTrabalho.js": CTRepository,
		"../../dti_modulos_netsuite/src/Service/dtiFuncionarioService.js": funcionarioService,
	});//Fim do script
}); //Fim do beforEach

test("Teste da função \"doGet\" - Com nome social", () => {
	let mockRequestParams = {};
	let mockFuncionario = [{
		id: "id",
		primeiroNome: "primeiroNome",
		nomeDoMeio: "nomeDoMeio",
		ultimoNome: "ultimoNome",
		nomeSocial: "nomeSocial",
		idTribo: "idTribo",
		idTriboAnterior: "idTriboAnterior",
		dataTransferencia: "dataTransferencia",
		idResponsavelMudanca: "idResponsavelMudanca",
		cpf: "cpf",
		idAtivo: "idAtivo",
		idCalendario: "idCalendario",
		telefone: "telefone",
		email: "email",
		idServico: "idServico",
		emailAlternativo: "emailAlternativo",
		idAdmissao: "idAdmissao",
		idMoeda: "idMoeda",
		idSexo: "idSexo",
		idSupervisor: "idSupervisor",
		idSubsidiaria: "idSubsidiaria",
		idDocumentacaoAdmissao: "idDocumentacaoAdmissao",
		idInstituicaoDeEnsino: "idInstituicaoDeEnsino",
		pcd: "pcd",
		dataNascimento: "dataNascimento",
	}];

	let mockRetorno = {
		nome: "Elaine Costa Cruz",
		primeiroNome: "primeiroNome",
		nomeDoMeio: "nomeDoMeio",
		ultimoNome: "ultimoNome",
		nomeSocial: "nomeSocial",
		id: "id",
		idTribo: "idTribo",
		idTriboAnterior: "idTriboAnterior",
		dataTransferencia: "dataTransferencia",
		idResponsavelMudanca: "idResponsavelMudanca",
		cpf: "cpf",
		idAtivo: "idAtivo",
		idCalendario: "idCalendario",
		telefone: "telefone",
		email: "email",
		idServico: "idServico",
		emailAlternativo: "emailAlternativo",
		idAdmissao: "idAdmissao",
		idMoeda: "idMoeda",
		idSexo: "idSexo",
		idSupervisor: "idSupervisor",
		idSubsidiaria: "idSubsidiaria",
		idDocumentacaoAdmissao: "idDocumentacaoAdmissao",
		idInstituicaoDeEnsino: "idInstituicaoDeEnsino",
		pcd: "pcd",
		dataNascimento: "dataNascimento",
	};

	CTRepository.buscaFuncionariosComCTAtivo.mockReturnValueOnce(mockFuncionario);
	funcionarioService.retornaNome.mockReturnValueOnce("Elaine Costa Cruz");

	let retorno = script.get(mockRequestParams);

	expect(CTRepository.buscaFuncionariosComCTAtivo).toHaveBeenCalled();
	expect(retorno).toEqual(JSON.stringify(mockRetorno));
});

test("Teste da função \"doGet\" - Sem nome social", () => {
	let mockRequestParams = {};
	let mockFuncionario = [{
		id: "id",
		primeiroNome: "primeiroNome",
		nomeDoMeio: "nomeDoMeio",
		ultimoNome: "ultimoNome",
		nomeSocial: null,
		idTribo: "idTribo",
		idTriboAnterior: "idTriboAnterior",
		dataTransferencia: "dataTransferencia",
		idResponsavelMudanca: "idResponsavelMudanca",
		cpf: "cpf",
		idAtivo: "idAtivo",
		idCalendario: "idCalendario",
		telefone: null,
		email: null,
		idServico: "idServico",
		emailAlternativo: "emailAlternativo",
		idAdmissao: "idAdmissao",
		idMoeda: "idMoeda",
		idSexo: "idSexo",
		idSupervisor: "idSupervisor",
		idSubsidiaria: "idSubsidiaria",
		idDocumentacaoAdmissao: "idDocumentacaoAdmissao",
		idInstituicaoDeEnsino: "idInstituicaoDeEnsino",
		pcd: "pcd",
		dataNascimento: "dataNascimento",
	}];

	let mockRetorno = {
		nome: "Elaine Costa Cruz",
		primeiroNome: "primeiroNome",
		nomeDoMeio: "nomeDoMeio",
		ultimoNome: "ultimoNome",
		nomeSocial: null,
		id: "id",
		idTribo: "idTribo",
		idTriboAnterior: "idTriboAnterior",
		dataTransferencia: "dataTransferencia",
		idResponsavelMudanca: "idResponsavelMudanca",
		cpf: "cpf",
		idAtivo: "idAtivo",
		idCalendario: "idCalendario",
		telefone: null,
		email: null,
		idServico: "idServico",
		emailAlternativo: "emailAlternativo",
		idAdmissao: "idAdmissao",
		idMoeda: "idMoeda",
		idSexo: "idSexo",
		idSupervisor: "idSupervisor",
		idSubsidiaria: "idSubsidiaria",
		idDocumentacaoAdmissao: "idDocumentacaoAdmissao",
		idInstituicaoDeEnsino: "idInstituicaoDeEnsino",
		pcd: "pcd",
		dataNascimento: "dataNascimento",
	};

	CTRepository.buscaFuncionariosComCTAtivo.mockReturnValueOnce(mockFuncionario);
	funcionarioService.retornaNome.mockReturnValueOnce("Elaine Costa Cruz");

	let retorno = script.get(mockRequestParams);

	expect(CTRepository.buscaFuncionariosComCTAtivo).toHaveBeenCalled();
	expect(retorno).toEqual(JSON.stringify(mockRetorno));
});