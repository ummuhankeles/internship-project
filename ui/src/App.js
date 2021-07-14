import React, { Component } from 'react';
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom';
import Home from './components/home/Home';
import ShoppingListForm from './components/shopping-list-form/ShoppingListForm';
import ShoppingList from './components/shopping-list/ShoppingList';
import Content from './components/content/Content';

class App extends Component {

  constructor(props) {
    super(props);
    this.state = {
      id: "",
      input: "",
      itemData: "",
      todos: [],
      shortURL: ""
    };
  }

  handleClick = () => {
    if(this.state.input === '' || this.state.input === null) {
      alert("Please enter the input !");
    }
    var url = 'http://localhost:8080/ShopList'
      fetch(url, {
        method: 'POST',
        headers:{
          'X-Requested-With': 'XMLHttpRequest',
          'Accept': 'application/json, text/plain, */*',
          'Content-Type': 'application/json; charset=UTF-8',
          'Access-Control-Allow-Origin': '*'
        },
        body: JSON.stringify({
          name: this.state.input,
          shortURL: this.state.shortURL,
          items: this.state.todos
        })
      }).then(res => res.json())
      .then(response => {
        //console.log('click', response)
        this.setState({
          input: response.name, 
          shortURL: response.shortURL, 
          todos: response.items
        })
      }
      )
      .catch(error => console.error('Error:', error));
  }

  // set home page input
  setInput = (e) => {
    const newVal = e.target.value;
    this.setState({
      input: newVal,
    });
  }

  // add item
  handleCreate = () => {

    var url = `http://localhost:8080/ShopItem/${this.state.shortURL}`;
    fetch(url, {
      method: 'POST',
      headers:{
        'X-Requested-With': 'XMLHttpRequest',
        'Accept': 'application/json, text/plain, */*',
        'Content-Type': 'application/json; charset=UTF-8',
        'Access-Control-Allow-Origin': '*'
      },
      body: JSON.stringify({
        name: this.state.itemData,
        definition: 'string',
        status: 0
      })
    }).then(res => res.json())
    .then(response => {
      //console.log('create', response.name)
      this.setState({
        id: response.id,
        itemData: response.name,
        todos: [...this.state.todos, response.name]
      })
    }
    )
    .catch(error => console.error('Error:', error));
  }

  // delete state and textarea box
  handleDelete = () => {
    if(this.state.itemData === "") {
      alert("Input box already empty !");
    }
    this.setState({
      itemData: "",
    });
  }

  // set item change
  dataChange = (e) => {
    const newVal = e.target.value;
    this.setState({
      itemData: newVal,
    });
  }

  // delete item
  deleteItem = (id) => {
    const currentValue = [...this.state.todos];
    const newVal = currentValue.filter(item => item.id !== id);
    this.setState({ todos: newVal })
  }

  render() {
    return (
      <div className="container">
        <Router>
          <Switch>
            <Route exact path="/">
              <Home
                input={this.state.input}
                setInput={this.setInput}
                handleClick={this.handleClick}
              />
            </Route>
            <Route path="/shopping-list" component={ShoppingListForm}>
              <Content
                input={this.state.input}
              />
              <ShoppingListForm
                itemData={this.state.itemData}
                handleCreate={this.handleCreate}
                dataChange={this.dataChange}
                handleDelete={this.handleDelete}
              />
              <ShoppingList
                setState={this.setState}
                state={this.state}
                deleteItem={this.deleteItem}
              />
            </Route>
          </Switch>
        </Router>
      </div>
    );
  }
}

export default App;
