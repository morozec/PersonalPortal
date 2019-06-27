import React from 'react'
import ReactDOM from 'react-dom';
import { BrowserRouter, Route, Switch, Redirect} from 'react-router-dom';
import Header from './header/Header';
import About from './about/About';
import Blog from './blog/Blog';
import Comments from '../containers/comments/comments';
import NewPost from '../containers/newPost/newPost';

export default class App extends React.Component{
    render(){
        return (
            <BrowserRouter>
                <div>
                    <Header/>
                    <main>
                        <Switch>
                            <Route path="/about" component={About} />
                            <Route path="/blog/new" component={NewPost} />
                            <Route path="/blog/post" component={Comments} />
                            <Route path="/blog" component={Blog} />
                            <Route exact path="/" render={() => (<Redirect to="/blog" />)} />
                        </Switch>
                    </main>                    
                </div>
            </BrowserRouter>
        )
    }
}