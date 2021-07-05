import React from 'react';
import ShoppingListItem from '../shopping-list-item/ShoppingListItem';

function ShoppingList(props) {

    const listItemStyle = {
        width: '100%',
        marginLeft: '-15px',
        borderRadius: '15px',
    }

    return (
        <div className="container">
            <ul>
                {
                    props.todos.map((item) => {
                        return(
                            <li style={listItemStyle} className="col-sm-12 list-group-item mb-3">
                                <ShoppingListItem {...item} key={item.id} />
                            </li>
                        )
                    })
                }
            </ul>
        </div>
    )
}
export default ShoppingList;