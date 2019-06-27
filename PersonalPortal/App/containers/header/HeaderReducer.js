import {LOGIN_ERROR, INPUT_LOGIN, INPUT_PASSWORD, LOGIN_SUCCESS, LOGOUT, SHOW_LOGIN_FORM} from './HeaderConstants'
import AuthHelper from "../../utils/AuthHelper"

const initialState = {
    isLogged:AuthHelper.isLogged(),
    name:AuthHelper.getLogin(),
    password:'',
    error:'',
    isLoginFormShown:false
}

export default function header(state = initialState, action){
    switch(action.type){
        case LOGIN_SUCCESS:
            return { ...state, isLogged: true, isLoginFormShown:false, name:action.payload, password: '', error: ''}
        case LOGIN_ERROR:
            return { ...state, error: action.payload }
    
        case LOGOUT:
            return { ...state, isLogged: false, name: '', password: '' }

        case SHOW_LOGIN_FORM:
            return { ...state, isLoginFormShown: action.payload }

        case INPUT_LOGIN:
            return {...state, name: action.payload }

        case INPUT_PASSWORD:
            return {...state, password: action.payload }

        default:
            return state;
    }
}