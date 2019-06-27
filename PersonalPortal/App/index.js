import React from 'react'
import ReactDOM from 'react-dom';
import { createStore, applyMiddleware } from 'redux'
import { Provider } from 'react-redux'
import thunk from 'redux-thunk'

import App from './containers/App'
import RootReducer from './RootReducer'
import BlogReducer from './containers/blog/BlogReducer'
import HeaderReducer from './containers/header/HeaderReducer'

function configureStore(initialState){
    const store = createStore(RootReducer, initialState, applyMiddleware(thunk)) 
    return store

}

const store = configureStore()

ReactDOM.render(
    <Provider store={store}>
        <App/>
    </Provider>,
    document.getElementById('root')
)