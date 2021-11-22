namespace OrdenEdit {

    var Entity = $("#AppEdit").data("entity");

    var Formulario = new Vue(
        {
            data:
            {
                Formulario: '#FordEdit',
                Entity: Entity
            },

            methods: {
                Save() {
                    if (BValidateData(this.Formulario)) {
                        Loading.fire("Guardado")
                        App.AxiosProvider.OrdenGuardar(this.Entity).then(data => {
                            Loading.close();
                            if (data.CodeError == 0) {
                                Toast.fire({ title: "Se Guardo Correctamente", icon: "success" }).then(() => window.location.href="Orden/Grid");
                            }
                            else {
                                Toast.fire({ title: data.MsgError, icon: "error" });
                            }
                        })
                    }
                    else {
                        Toast.fire({ title: "Por Favor Complete Los Campos Requerido" })
                    }
                }
            },


            mounted() {
                CreateValidator(this.Formulario)
            }
        }
    );
    Formulario.$mount("#AppEdit")
    
}
