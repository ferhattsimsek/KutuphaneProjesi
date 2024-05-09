

function favoritemanage(obj){
    const i=obj.querySelector(".add-favorite-btn")

    let check = i.classList.contains('fa-regular');
    console.log(check);

    if(check){
        addfavorite(obj)
        
         let text="Favorilere Eklendi"
           let mesaj= toastr.options = {
              "closeButton": true, 
              "debug": false,
              "progressBar": false,
              "preventDuplicates": true,
              "positionClass": "toast-top-right", 
              "showDuration": "200",
              "hideDuration": "2000",
              "timeOut": "20000", 
              "extendedTimeOut": "2000",
              "showEasing": "swing",
              "hideEasing": "linear",
              "showMethod": "fadeIn",
              "hideMethod": "fadeOut",
              
            }
            toastr["success"](mesaj,text);
            
            

    }
    else{
        removefavorite(obj)
        let text="Favorilerden Çıkartıldı"
           let mesaj= toastr.options = {
              "closeButton": true, 
              "debug": false,
              "progressBar": false,
              "preventDuplicates": true,
              "positionClass": "toast-top-right", 
              "showDuration": "200",
              "hideDuration": "2000",
              "timeOut": "20000", 
              "extendedTimeOut": "2000",
              "showEasing": "swing",
              "hideEasing": "linear",
              "showMethod": "fadeIn",
              "hideMethod": "fadeOut",
              
            }
            toastr["warning"](mesaj,text);
            
    
    }
    
   
    
}
function showcontent(mesaj){
    
}



function addfavorite(obj){
    const add=obj.querySelector(".add-favorite-btn")
    add.classList.remove("fa-regular")
    add.classList.add("fa-solid")
    add.style.color="#CD2026"
  
    
        
     }
   
    


  function removefavorite(obj){
        const remove=obj.querySelector(".add-favorite-btn")
        
            remove.classList.remove("fa-solid")
            remove.classList.add("fa-regular")
    
        };




// heart.addEventListener("click",e=>{
//     e.preventDefault()


    
//    

// })