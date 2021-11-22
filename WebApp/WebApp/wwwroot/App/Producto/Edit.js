"use strict";
var ProductoEdit;
(function (ProductoEdit) {
    var Entity = $("#AppEdit").data("entity");
    var Formulario = new Vue({
        data: {
            Formulario: '#FordEdit',
            Entity: Entity
        },
        methods: {
            Save: function () {
                if (BValidateData(this.Formulario)) {
                    Loading.fire("Guardado");
                    App.AxiosProvider.ProductoGuardar(this.Entity).then(function (data) {
                        Loading.close();
                        if (data.CodeError == 0) {
                            Toast.fire({ title: "Se Guardo Correctamente", icon: "success" }).then(function () { return window.location.href = "Producto/Grid"; });
                        }
                        else {
                            Toast.fire({ title: data.MsgError, icon: "error" });
                        }
                    });
                }
                else {
                    Toast.fire({ title: "Por Favor Complete Los Campos Requerido" });
                }
            }
        },
        mounted: function () {
            CreateValidator(this.Formulario);
        }
    });
    Formulario.$mount("#AppEdit");
})(ProductoEdit || (ProductoEdit = {}));
//# sourceMappingURL=Edit.js.map