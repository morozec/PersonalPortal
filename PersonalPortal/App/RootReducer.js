import { combineReducers } from 'redux'
import blog from './containers/blog/BlogReducer'
import header from './containers/header/HeaderReducer'
import newPost from './containers/newPost/newPostReducer'
import comments from './containers/comments/commentsReducer'

export default combineReducers({
    blog, 
    header,
    newPost,
    comments
})