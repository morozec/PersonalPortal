import React from 'react'
import ReactDOM from 'react-dom'

export default class LoginForm extends React.Component{
    render(){
        return (
            <div className="loginForm">
                <div className="row">Логин: <input type="input" value={this.props.login} onChange={e => this.props.onChangeLogin(e.target.value)} className="input" /></div>
                <div className="row">Пароль: <input type="input" value={this.props.password} onChange={e => this.props.onChangePassword(e.target.value)} className="input" /></div>
                <div className="row"><input type="button" value="Войти" onClick={e => this.props.onLogin(this.props.login, this.props.password)} className="input" /></div>
            </div>
        )
    }
}