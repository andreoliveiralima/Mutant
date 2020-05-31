let vAbrirPedido;
let vListarLanches;
let vListarPedidosAbertos;
let vListarIngredientesLanche;
let vInserirItemPedido;
let idIngredientes = [];
let ingredientes = [];

function AbrirPedido() {
    Swal.fire({
        title: 'Deseja abrir novo pedido?',
        text: "",
        type: 'question',
        background: 'rgba(0,0,0,0) linear-gradient(#444,#111) repeat scroll 0 0',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        cancelButtonText: 'Não',
        confirmButtonText: 'Sim'
    }).then((result) => {
        if (result.value) {
            $("#dropPedidosAbertos").hide();
            Aguarde();
            $.ajax({
                url: vAbrirPedido,
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                type: 'get',
                traditional: true,
                success: function (data) {
                    $.each(data, function (i, state) {
                        $("#txtIdPedido").val(state.idPedido);
                    });
                    FimAguarde();
                    swal({
                        title: "Sucesso!",
                        text: "Banco salvo com sucesso!",
                        type: "success",
                        background: 'rgba(0,0,0,0) linear-gradient(#444,#111) repeat scroll 0 0',
                        confirmButtonText: "OK"
                    }).then((result) => {
                        if (result.value || result.dismiss == "overlay") {
                            $("#dropPedidosAbertos").hide();
                            $("#btnPedidoAberto").hide();
                            CarregaDropLanche();
                            $("#divLanche").show();
                        }
                    });
                }
            });
        };
    });
}

function CarregaDropLanche() {
    let vdrop = $("#dropLanche");
    vdrop.empty();
    Aguarde();
    vdrop.append("<option value='0' selected>Selecione um Lanche...</option>");
    $.ajax({
        url: vListarLanches,
        data: {},
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        type: 'get',
        traditional: true,
        success: function (data) {
            $.each(data, function (i, state) {
                vdrop.append($('<option />').attr('value', (state.idLanche)).text(state.nomeLanche));
            });
        },
        complete: function () {
            FimAguarde();
        }
    });
}

function CarregaDropPedidosAbertos() {
    let vdrop = $("#dropPedidosAbertos");
    vdrop.empty();
    Aguarde();
    vdrop.append("<option value='0' selected>Pedidos Abertos - Selecione um Pedido...</option>");
    $.ajax({
        url: vListarPedidosAbertos,
        data: {},
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        type: 'get',
        traditional: true,
        success: function (data) {
            $.each(data, function (i, state) {
                vdrop.append($('<option />').attr('value', (state.idPedido)).text(state.idPedido));
            });
        },
        complete: function () {
            FimAguarde();
        }
    });
}

function CarregaIngredientesLanche() {
    let vdiv = $("#divIngredientes");
    let parte = "";
    vdiv.empty();
    Aguarde();
    $.ajax({
        url: vListarIngredientesLanche,
        data: { id: parseInt($("#dropLanche option:selected").val()) },
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        type: 'get',
        traditional: true,
        success: function (data) {
            idIngredientes = [];
            parte = "<div class='row clearfix'>";
            parte += "<div class='col-md-3' style='padding-right: 0px; padding-left: 0px; padding-top: 15px; text-align:left; border-bottom:solid; border-bottom-color:aliceblue; border-bottom-width:thin'>";
            parte += "<label style='max-width:100%; font-size:large font-style: italic; font-weight: 500; color: cornflowerblue;'>Ingrediente</label>";
            parte += "</div >";
            parte += "<div class='col-md-3' style='padding-right: 0px; padding-left: 0px; padding-top: 15px; text-align:left; border-bottom:solid; border-bottom-color:aliceblue; border-bottom-width:thin'>";
            parte += "<label style='max-width:100%; font-size:large font-style: italic; font-weight: 500; color: cornflowerblue;'>Valor</label>";
            parte += "</div >";
            parte += "<div class='col-md-3' style='padding-right: 0px; padding-left: 0px; padding-top: 15px; text-align:left; border-bottom:solid; border-bottom-color:aliceblue; border-bottom-width:thin'>";
            parte += "<label style='max-width:100%; font-size:large font-style: italic; font-weight: 500; color: cornflowerblue;'>Quantidade</label>";
            parte += "</div >";
            vdiv.append(parte);
            $.each(data, function (i, state) {
                parte = "<div class='row clearfix'>";
                parte += "<div class='col-md-3' style='padding-right: 0px; padding-left: 0px; padding-top: 15px; text-align:left; border-bottom:solid; border-bottom-color:aliceblue; border-bottom-width:thin'>";
                parte += "<label style='max-width:100%; font-size:large'>" + state.nomeIngrediente + "</label>";
                parte += "</div >";
                parte += "<div class='col-md-3' style='padding-right: 0px; padding-left: 0px; padding-top: 15px; text-align:left; border-bottom:solid; border-bottom-color:aliceblue; border-bottom-width:thin'>";
                parte += "<label id='txtValor" + state.idIngrediente + "' name='txtValor" + state.idIngrediente + "'style='max-width:100%; font-size:large'>" + state.valorIngrediente + "</label>";
                parte += "</div >";
                parte += "<div class='col-md-3' style='padding-right: 0px; padding-left: 0px; padding-top: 15px; text-align:left; border-bottom:solid; border-bottom-color:aliceblue; border-bottom-width:thin'>";
                parte += "<input id='txtQuantidade" + state.idIngrediente + "' name='txtQuantidade" + state.idIngrediente + "' value=" + parseInt(state.quantidade) + " type='number' step='1' class='form - control' placeholder='Quantidade' maxlength='2' style='max - width: 100 %; font - size: small; ' />";
                parte += "</div >";
                parte += "</div >";
                idIngredientes.push(state.idIngrediente);
                vdiv.append(parte);
                vdiv.slideDown(1000);
            });
        },
        error: function (error) {
            FimAguarde();
            swal({
                title: "Erro!",
                text: "Erro Função Listar Unidades",
                type: "error",
                background: 'rgba(0,0,0,0) linear-gradient(#444,#111) repeat scroll 0 0',
                confirmButtonText: "OK"
            });
        },
        complete: function () {
            FimAguarde();
        }
    });
}

function ObjItemPedido(_idPedido, _idLanche, _ingrediente) {
    this.idItemPedido = 0;
    this.idPedido = _idPedido;
    this.idLanche = _idLanche;
    this.ingrediente = _ingrediente;
}

function MontaObjetoItemPedido() {
    return new ObjItemPedido(
        parseInt($("#txtIdPedido").val()),
        parseInt($("#dropLanche").val()),
        ingredientes);
}

function ObjIngrediente(_ingrediente, _valor, _quantidade) {
    this.idItemPedidoIngrediente = 0;
    this.idItemPedido = 0;
    this.idIngrediente = _ingrediente;
    this.valor = _valor;
    this.valorDesconto = 0;
    this.quantidade = _quantidade;
    this.nomeIngrediente = "";
}

function MontaObjetoIngrediente(idIngrediente) {
    return new ObjIngrediente(
        idIngrediente,
        parseFloat($("#txtValor" + idIngrediente).text()),
        parseInt($("#txtQuantidade" + idIngrediente).val()));
}

function InserirLanche() {
    Swal.fire({
        title: 'Deseja inserir este lanche?',
        text: "",
        type: 'question',
        background: 'rgba(0,0,0,0) linear-gradient(#444,#111) repeat scroll 0 0',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        cancelButtonText: 'Não',
        confirmButtonText: 'Sim'
    }).then((result) => {
        if (result.value) {
            Aguarde();
            ingredientes = [];
            for (x = 0; x < idIngredientes.length; x++) {
                ingredientes.push(MontaObjetoIngrediente(idIngredientes[x]))
            }
            let objeto = MontaObjetoItemPedido();
            $.ajax({
                url: vInserirItemPedido,
                data: JSON.stringify(objeto),
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                type: 'POST',
                traditional: true,
                success: function (data) {
                    if (data == "OK") {
                        swal({
                            title: "Sucesso!",
                            text: "Item Inserido com sucesso!",
                            type: "success",
                            background: 'rgba(0,0,0,0) linear-gradient(#444,#111) repeat scroll 0 0',
                            confirmButtonText: "OK"
                        }).then((result) => {
                            if (result.value || result.dismiss == "overlay") {
                                $("#dropLanche").val(0);
                                $("#divIngredientes").empty();
                                $("#btnInserirLanche").hide();
                                idIngredientes = [];
                                ingredientes = [];
                            }
                        });
                    }
                    else {
                        swal({
                            title: "Erro!",
                            text: "Erro ao inserir lanche!",
                            type: "error",
                            background: 'rgba(0,0,0,0) linear-gradient(#444,#111) repeat scroll 0 0',
                            confirmButtonText: "OK"
                        }).then((result) => {
                            if (result.value || result.dismiss == "overlay") {
                                $("#dropLanche").val(0);
                                $("#divIngredientes").empty();
                                $("#btnInserirLanche").hide();
                                idIngredientes = [];
                                ingredientes = [];
                            }
                        });
                    };
                },
                complete: function () {

                }
            });
        };
    });
}

function ArrumaTela() {
    $("#dropPedidosAbertos").show();
    $("#btnAbrirPedido").hide();
}

function LimparTela() {
    $("#dropPedidosAbertos").hide();
    $("#btnInserirLanche").hide();
    $("#divLanche").hide();
    $("#txtIdPedido").val("");
    $("#btnPedidoAberto").show();
    $("#btnAbrirPedido").show();
    $("#divIngredientes").empty();
    $("#dropLanche").val(0);
    $("#dropPedidosAbertos").val(0);
    idIngredientes = [];
    ingredientes = [];
}