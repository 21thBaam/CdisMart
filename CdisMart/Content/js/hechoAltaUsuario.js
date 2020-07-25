function hecho(){
	Swal.fire({
	  position: 'top-end',
        icon: 'success',
	  title: 'Registro Satisfactorio',
	  showConfirmButton: false,
	  timer: 1500
    }).then((result) => {
        window.location.replace("../Login.aspx");
	    });
}