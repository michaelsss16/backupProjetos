const { loadSuiteScriptModule, NSearch } = require("../../../dti_netsumo");
const Constantes = require("../../../mocks/modulos/consts");

const consts = new Constantes();
const ScriptBuscaTribosDetalhado = loadSuiteScriptModule("../RESTLet_Script/Funcionarios/dti_buscaTribosDetalhado.restlet.js", true);

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
	triboRepository = {
		buscaTriboRound: jest.fn(),
	};

	script = ScriptBuscaTribosDetalhado({
		"N/search": nSearch,
		"../../dti_modulos_netsuite/src/dti_constantes.js": consts,
		"../../dti_modulos_netsuite/src/dti_util.js": dtiUtil,
		"../../dti_modulos_netsuite/src/Repository_dtiContratoDeTrabalho.js": CTRepository,
		"../../dti_modulos_netsuite/src/Repository/dtiTriboRepository.js": triboRepository,
		"../../dti_modulos_netsuite/src/Service/dtiFuncionarioService.js": funcionarioService,
	});
});

test("Teste da função \"doGet\" ", () => {
	let mockRequestParams = {};
	let mockTribos = [{
		id: "idTribo",
		nome: "nomeAliancaTribo",
		alianca: "alianca",
		temVisibilidadeDasDespesas: "temVisibilidadeDasDespesas",
		ehTriboIndireta: "ehTriboIndireta",
		nomeTribo: "nomeTribo",
	}];
	let mockRetorno = {
		id: "idTribo",
		nome: "nomeAliancaTribo",
		alianca: "alianca",
		temVisibilidadeDasDespesas: "temVisibilidadeDasDespesas",
		ehTriboIndireta: "ehTriboIndireta",
		nomeTribo: "nomeTribo",
	};

	triboRepository.buscaTriboRound.mockReturnValueOnce(mockTribos);
	let retorno = script.get(mockRequestParams);

	expect(triboRepository.buscaTriboRound).toHaveBeenCalled();
	expect(retorno).toEqual(JSON.stringify(mockRetorno));
});