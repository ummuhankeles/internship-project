import React from 'react';
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom';
import Home from './components/home/Home';
import ShoppingList from './components/shopping-list/ShoppingList';

function App() {
  return (
    <div className="container">
      <Router>
        <Switch>
          <Route exact path="/">
            <Home/>
          </Route>
          <Route path="/shopping-list" component={ShoppingList}>
            <ShoppingList/>
          </Route>
        </Switch>
      </Router>
    </div>
  );
}

export default App;
