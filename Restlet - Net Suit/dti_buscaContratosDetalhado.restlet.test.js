const { loadSuiteScriptModule, NSearch } = require("../../../dti_netsumo");
const Constantes = require("../../../mocks/modulos/consts");

const consts = new Constantes();
const ScriptBuscaContratosDetalhado = loadSuiteScriptModule("../RESTLet_Script/Funcionarios/dti_buscaContratosDetalhado.restlet.js", true);

let nSearch;
let dtiUtil;
let CTRepository;
let triboRepository;
let funcionarioService;

let script;

beforeEach(() => {
	nSearch = new NSearch();
	dtiUtil = {
		criaNewDatePorString: jest.fn(),
	};
	dtiUtil.criaNewDatePorString.mockImplementation((data) => {
		var dataComSplit = data.split("/");

		var dia = 0;
		var mes = 0;
		var ano = 0;

		dia = parseInt(dataComSplit[0], 10);
		mes = parseInt(dataComSplit[1], 10) - 1;
		ano = parseInt(dataComSplit[2], 10);

		return (new Date(ano, mes, dia, 0, 0, 0, 0));
	});
	CTRepository = {
		buscaTodosOsContratosVigentes: jest.fn(),
	};

	script = ScriptBuscaContratosDetalhado({
		"N/search": nSearch,
		"../../dti_modulos_netsuite/src/dti_constantes.js": consts,
		"../../dti_modulos_netsuite/src/dti_util.js": dtiUtil,
		"../../dti_modulos_netsuite/src/Repository_dtiContratoDeTrabalho.js": CTRepository,
		"../../dti_modulos_netsuite/src/Service/dtiFuncionarioService.js": funcionarioService,
	});
});

test("Teste da função \"doGet\" ", () => {
	let mockRequestParams = {};
	let mockContrato = [{
		id: "id",
		dataInicio: "dataInicio",
		dataFim: "dataFim",
		tipo: "tipo",
		horario: "horario",
		ctps: "ctps",
		tempoDti: "tempoDti",
	}];

	let mockRetorno = {
		id: "id",
		dataInicio: "dataInicio",
		dataFim: "dataFim",
		tipo: "tipo",
		horario: "horario",
		ctps: "ctps",
		tempoDti: "tempoDti",

	};

	CTRepository.buscaTodosOsContratosVigentes.mockReturnValueOnce(mockContrato);
	let retorno = script.get(mockRequestParams);

	expect(CTRepository.buscaTodosOsContratosVigentes).toHaveBeenCalled();
	expect(retorno).toEqual(JSON.stringify(mockRetorno));
});
