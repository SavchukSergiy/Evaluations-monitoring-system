import React, {useEffect, useState} from 'react';
import {Auth} from './pages/Auth/auth';
import {Home} from './pages/Home/home';
import { BrowserRouter as Router, Redirect, Route, Switch } from 'react-router-dom';
import {http} from './services/test-service';

function App() {

  const [list, setList] = useState([]);

  useEffect(() => {
    let mounted = true;
    http('https://jsonplaceholder.typicode.com/posts/1')
    .then(items => {
      if (mounted) {
        setList(items)
      }
    })
    return () => mounted = false;
  }, []);

  console.log(list.title);

  return (
    <Router>
      <Switch>
        <Route path='/' exact component={Auth}/>
        <Route path='/dashboard' exact component={Home}/>
      </Switch>
    </Router>
  );
}

export default App;
