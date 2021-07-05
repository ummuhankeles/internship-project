import React from 'react';
import { MdDeleteForever } from 'react-icons/md';

function ShoppingListItem(props) {

    const { id } = props;

    const iconStyle = {
        float: 'right',
        color: '#E30202',
        fontSize: '25px',
        cursor: 'pointer'
    }

    return (
        <div>
            {props.content}
            <MdDeleteForever style={iconStyle} onClick={() => props.deleteItem(id)} />
        </div>
    )
}

export default ShoppingListItem;