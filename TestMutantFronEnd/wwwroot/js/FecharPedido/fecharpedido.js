let vFecharPedido;
let vListarPedidosAbertos;
let vListarItensPedido;
let vAplicarPromocao;


function FecharPedido() {
    Swal.fire({
        title: 'Deseja fechar o pedido?',
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
            $.ajax({
                url: vFecharPedido,
                data: { id: parseInt($("#dropPedidosAbertos option:selected").val()) },
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                type: 'get',
                traditional: true,
                success: function (data) {
                    if (data == "OK") {
                        swal({
                            title: "Sucesso!",
                            text: "Pedido fechado com sucesso!",
                            type: "success",
                            background: 'rgba(0,0,0,0) linear-gradient(#444,#111) repeat scroll 0 0',
                            confirmButtonText: "OK"
                        }).then((result) => {
                            if (result.value || result.dismiss == "overlay") {
                                CarregaDropPedidosAbertos();
                                LimparTela();
                            }
                        });
                    }
                    else {
                        swal({
                            title: "Erro!",
                            text: "Erro ao fechar pedido!",
                            type: "error",
                            background: 'rgba(0,0,0,0) linear-gradient(#444,#111) repeat scroll 0 0',
                            confirmButtonText: "OK"
                        }).then((result) => {
                            if (result.value || result.dismiss == "overlay") {
                                
                            }
                        });
                    };
                }
            });
        };
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
    let idItemPedido = "";
    let valorTotal = 0;
    let descontoTotal = 0;
    let achou = false;
    vdiv.empty();
    Aguarde();
    $.ajax({
        url: vListarItensPedido,
        data: { id: parseInt($("#dropPedidosAbertos option:selected").val()) },
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        type: 'get',
        traditional: true,
        success: function (data) {
            $.each(data, function (i, state) {
                achou = true;
                if (idItemPedido == "" || idItemPedido != state.idItemPedido) {
                    parte = "<div class='row clearfix'>";
                    parte += "<div class='col-md-12' style='padding-right: 0px; padding-left: 0px; padding-top: 15px; text-align:left; border-bottom:solid; border-bottom-color:aliceblue; border-bottom-width:thin'>";
                    parte += "<label style='max-width:100%; font-size:large font-style: italic; font-weight: 500; color: cornflowerblue;'>" + state.nomeLanche + "</label>";
                    parte += "</div >";
                    parte += "</div >";
                    parte += "<div class='row clearfix'>";
                    parte += "<div class='col-md-3' style='padding-right: 0px; padding-left: 0px; padding-top: 15px; text-align:left; border-bottom:solid; border-bottom-color:aliceblue; border-bottom-width:thin'>";
                    parte += "<label style='max-width:100%; font-size:large font-style: italic; font-weight: 500; color: cornflowerblue;'>Ingrediente</label>";
                    parte += "</div >";
                    parte += "<div class='col-md-3' style='padding-right: 0px; padding-left: 0px; padding-top: 15px; text-align:left; border-bottom:solid; border-bottom-color:aliceblue; border-bottom-width:thin'>";
                    parte += "<label style='max-width:100%; font-size:large font-style: italic; font-weight: 500; color: cornflowerblue;'>Valor</label>";
                    parte += "</div >";
                    parte += "<div class='col-md-3' style='padding-right: 0px; padding-left: 0px; padding-top: 15px; text-align:left; border-bottom:solid; border-bottom-color:aliceblue; border-bottom-width:thin'>";
                    parte += "<label style='max-width:100%; font-size:large font-style: italic; font-weight: 500; color: cornflowerblue;'>Valor Desconto</label>";
                    parte += "</div >";
                    parte += "<div class='col-md-3' style='padding-right: 0px; padding-left: 0px; padding-top: 15px; text-align:left; border-bottom:solid; border-bottom-color:aliceblue; border-bottom-width:thin'>";
                    parte += "<label style='max-width:100%; font-size:large font-style: italic; font-weight: 500; color: cornflowerblue;'>Quantidade</label>";
                    parte += "</div >";
                    parte += "</div >";
                    vdiv.append(parte);
                    vdiv.slideDown(1000);
                    idItemPedido = state.idItemPedido;
                }

                parte = "<div class='row clearfix'>";
                parte += "<div class='col-md-3' style='padding-right: 0px; padding-left: 0px; padding-top: 15px; text-align:left; border-bottom:solid; border-bottom-color:aliceblue; border-bottom-width:thin'>";
                parte += "<label style='max-width:100%; font-size:large'>" + state.nomeProduto + "</label>";
                parte += "</div >";
                parte += "<div class='col-md-3' style='padding-right: 0px; padding-left: 0px; padding-top: 15px; text-align:left; border-bottom:solid; border-bottom-color:aliceblue; border-bottom-width:thin'>";
                parte += "<label style='max-width:100%; font-size:large'>" + state.valor + "</label>";
                parte += "</div >";
                parte += "<div class='col-md-3' style='padding-right: 0px; padding-left: 0px; padding-top: 15px; text-align:left; border-bottom:solid; border-bottom-color:aliceblue; border-bottom-width:thin'>";
                parte += "<label style='max-width:100%; font-size:large'>" + state.valorDesconto + "</label>";
                parte += "</div >";
                parte += "<div class='col-md-3' style='padding-right: 0px; padding-left: 0px; padding-top: 15px; text-align:left; border-bottom:solid; border-bottom-color:aliceblue; border-bottom-width:thin'>";
                parte += "<label style='max-width:100%; font-size:large'>" + state.quantidade + "</label>";
                parte += "</div >";
                parte += "</div >";
                valorTotal += (parseFloat(state.valor) * parseFloat(state.quantidade));
                descontoTotal += parseFloat(state.valorDesconto);
                vdiv.append(parte);
                vdiv.slideDown(1000);
            });
            if (achou) {
                parte = "<div class='row clearfix'>";
                parte += "<div class='col-md-3' style='padding-right: 0px; padding-left: 0px; padding-top: 15px; text-align:left; border-bottom:solid; border-bottom-color:aliceblue; border-bottom-width:thin'>";
                parte += "<label style='max-width:100%; font-size:large font-style: italic; font-weight: 500; color: cornflowerblue;'></label>";
                parte += "</div >";
                parte += "<div class='col-md-3' style='padding-right: 0px; padding-left: 0px; padding-top: 15px; text-align:left; border-bottom:solid; border-bottom-color:aliceblue; border-bottom-width:thin'>";
                parte += "<label style='max-width:100%; font-size:large font-style: italic; font-weight: 500; color: cornflowerblue;'>Valor Total</label>";
                parte += "</div >";
                parte += "<div class='col-md-3' style='padding-right: 0px; padding-left: 0px; padding-top: 15px; text-align:left; border-bottom:solid; border-bottom-color:aliceblue; border-bottom-width:thin'>";
                parte += "<label style='max-width:100%; font-size:large font-style: italic; font-weight: 500; color: cornflowerblue;'>Desconto Total</label>";
                parte += "</div >";
                parte += "<div class='col-md-3' style='padding-right: 0px; padding-left: 0px; padding-top: 15px; text-align:left; border-bottom:solid; border-bottom-color:aliceblue; border-bottom-width:thin'>";
                parte += "<label style='max-width:100%; font-size:large font-style: italic; font-weight: 500; color: cornflowerblue;'>Valor a Pagar</label>";
                parte += "</div >";
                parte += "</div >";
                parte += "<div class='row clearfix'>";
                parte += "<div class='col-md-3' style='padding-right: 0px; padding-left: 0px; padding-top: 15px; text-align:left; border-bottom:solid; border-bottom-color:aliceblue; border-bottom-width:thin'>";
                parte += "<label style='max-width:100%; font-size:large'></label>";
                parte += "</div >";
                parte += "<div class='col-md-3' style='padding-right: 0px; padding-left: 0px; padding-top: 15px; text-align:left; border-bottom:solid; border-bottom-color:aliceblue; border-bottom-width:thin'>";
                parte += "<label style='max-width:100%; font-size:large'>" + parseFloat(valorTotal) + "</label>";
                parte += "</div >";
                parte += "<div class='col-md-3' style='padding-right: 0px; padding-left: 0px; padding-top: 15px; text-align:left; border-bottom:solid; border-bottom-color:aliceblue; border-bottom-width:thin'>";
                parte += "<label style='max-width:100%; font-size:large'>" + parseFloat(descontoTotal) + "</label>";
                parte += "</div >";
                parte += "<div class='col-md-3' style='padding-right: 0px; padding-left: 0px; padding-top: 15px; text-align:left; border-bottom:solid; border-bottom-color:aliceblue; border-bottom-width:thin'>";
                parte += "<label style='max-width:100%; font-size:large'>" + parseFloat(valorTotal - descontoTotal) + "</label>";
                parte += "</div >";
                parte += "</div >";
                vdiv.append(parte);
                vdiv.slideDown(1000);
                $("#btnAplicarPromocao").show();
                $("#btnFecharPedido").show();
                FimAguarde();
            }
            else {
                swal({
                    title: "Aviso!",
                    text: "Pedido sem Itens",
                    type: "warning",
                    background: 'rgba(0,0,0,0) linear-gradient(#444,#111) repeat scroll 0 0',
                    confirmButtonText: "OK"
                });
            }
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
            
        }
    });
}

function AplicarPromocao() {
    Swal.fire({
        title: 'Deseja aplicar promoção a este pedido?',
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
            $.ajax({
                url: vAplicarPromocao,
                data: { id: parseInt($("#dropPedidosAbertos option:selected").val()) },
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                type: 'get',
                traditional: true,
                success: function (data) {
                    if (data == "OK") {
                        swal({
                            title: "Sucesso!",
                            text: "Promoção aplicada com sucesso!",
                            type: "success",
                            background: 'rgba(0,0,0,0) linear-gradient(#444,#111) repeat scroll 0 0',
                            confirmButtonText: "OK"
                        }).then((result) => {
                            if (result.value || result.dismiss == "overlay") {
                                CarregaIngredientesLanche();
                            }
                        });
                    }
                    else {
                        swal({
                            title: "Erro!",
                            text: "Erro ao aplicar promoção!",
                            type: "error",
                            background: 'rgba(0,0,0,0) linear-gradient(#444,#111) repeat scroll 0 0',
                            confirmButtonText: "OK"
                        }).then((result) => {
                            if (result.value || result.dismiss == "overlay") {

                            }
                        });
                    };
                }
            });
        };
    });
}


function LimparTela() {
    $("#btnAplicarPromocao").hide();
    $("#btnFecharPedido").hide();
    $("#divIngredientes").empty();
    $("#dropPedidosAbertos").val(0);
}