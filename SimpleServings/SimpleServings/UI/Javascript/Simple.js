function DeleteConfirmation() {
    if (window.confirm("Do you want to delete this recipe?")) {
        return true;
    }
    else {
        return false;
    }
}