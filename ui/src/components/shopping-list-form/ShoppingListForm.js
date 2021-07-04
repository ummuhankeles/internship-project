import React from 'react';
import './ShoppingListForm.css'

function ShoppingListForm({itemData, dataChange, handleCreate, handleDelete}) {

    const buttonStyle = {
        width: '100%',
        fontSize: '15px',
        borderRadius: '15px',
        letterSpacing: '2px'
    }

    function handleSubmit(e) {
        e.preventDefault();
    }

    return (
        <div className="container mt-5">
            <form className="row" onSubmit={handleSubmit}>
                <div className="col-sm-12 col-md-7 col-lg-9 shopping-list-input mb-3">
                    <textarea 
                        maxlength="70" 
                        placeholder="write note..."
                        value={itemData}
                        onChange={dataChange}
                    >
                    </textarea>
                </div>
                <div className="col-sm-12 col-md-5 col-lg-3 shopping-list-btn-box mb-3">
                    <button 
                        style={buttonStyle} 
                        type="button" 
                        className="btn btn-success mb-2"
                        onClick={handleCreate}
                    >
                    Create Item
                    </button>        
                    <button 
                        style={buttonStyle} 
                        type="button" 
                        className="btn btn-danger mb-2"
                        onClick={handleDelete}
                    >
                    Delete Item
                    </button>
                </div>
            </form>
        </div>
    )
}

export default ShoppingListForm;