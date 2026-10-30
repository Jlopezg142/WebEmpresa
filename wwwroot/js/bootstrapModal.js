window.bootstrapModal = {

    show: function (id) {

        const elemento = document.getElementById(id);

        if (!elemento) {
            return;
        }

        let modal = bootstrap.Modal.getInstance(elemento);

        if (!modal) {
            modal = new bootstrap.Modal(elemento);
        }

        modal.show();
    },


    hide: function (id) {

        const elemento = document.getElementById(id);

        if (!elemento) {
            return;
        }

        const modal = bootstrap.Modal.getInstance(elemento);

        if (modal) {
            modal.hide();
        }
    }

};