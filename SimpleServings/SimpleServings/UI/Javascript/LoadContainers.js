function CreateListContainer() {
        
    var list = document.getElementById("ctl08_column1");
    
    DragDrop.makeListContainer( list, 'g1' );
   
    list.onDragOver = function() { this.style["background"] = "none"; };
    
    
    list.onDragOut = function() {this.style["background"] = "none"; };

    list = document.getElementById("ctl08_column2");
    DragDrop.makeListContainer( list, 'g1' );
    list.onDragOver = function() { this.style["background"] = "none"; };
    list.onDragOut = function() {this.style["background"] = "none"; };

    list = document.getElementById("ctl08_column3");
    DragDrop.makeListContainer( list, 'g1' );
    list.onDragOver = function() { this.style["background"] = "none"; };
    list.onDragOut = function() {this.style["background"] = "none"; };

    list = document.getElementById("ctl08_column4");
    DragDrop.makeListContainer( list, 'g1' );
    list.onDragOver = function() { this.style["background"] = "none"; };
    list.onDragOut = function() {this.style["background"] = "none"; };

    list = document.getElementById("ctl08_column5");
    DragDrop.makeListContainer( list, 'g1' );
    list.onDragOver = function() { this.style["background"] = "none"; };
    list.onDragOut = function() {this.style["background"] = "none"; };
                            
}
        
function getSort()
{
    order = document.getElementById("order");
    order.value = DragDrop.serData('g1', null);
    //alert(order.value);
}

function showValue()
{
    order = document.getElementById("order");
    alert(order.value);
}
