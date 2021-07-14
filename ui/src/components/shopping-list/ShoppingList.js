import React, { useEffect } from 'react';
import { MdDeleteForever } from 'react-icons/md';


function ShoppingList({state, setState}, props) {

    //const { id } = props;

    const iconStyle = {
        float: 'right',
        color: '#E30202',
        fontSize: '25px',
        cursor: 'pointer'
    }

    const listItemStyle = {
        width: '100%',
        marginLeft: '-15px',
        borderRadius: '15px',
    }

    useEffect(() => {
        var url = `http://localhost:8080/ShopList/${state.shortURL}`;
        fetch(url, {
            method: 'GET',
            headers: {
                'Accept': 'application/json, text/plain, */*'
            }
        }).then(res => res.json())
        .then(response => {
            //console.log('get', response)
            setState({
                input: response.name,
                shortURL: response.shortURL,
                itemData: response.items.name,
                todos: [...state.todos, response.items]
            })
        }
        )
        .catch(error => console.error('Error:', error));
    }, [state])

    const {todos} = state;

    return (
        <div className="container">
            <ul>
                {
                    todos.map((item) => {
                        return(
                        <li style={listItemStyle} key={item.id} className="col-sm-12 list-group-item mb-3">
                            {item}
                            <MdDeleteForever style={iconStyle} onClick={() => props.deleteItem()} />
                        </li>
                    )
                    })
                }
            </ul>
        </div>
    )
}
export default ShoppingList;