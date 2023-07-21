import { combineReducers } from 'redux';
import listParamReducer from './listParamSlice';
import counterReducer from './counter/counterSlice';
import oauthReducer from './oauth/oauthSlice';
import examReducer from './perFormExam/perFormExam';
import galleryReducer  from './gallery/gallerySlice';
const reducers = combineReducers({
    oauth: oauthReducer,
    counter: counterReducer,
    listParam: listParamReducer,
    gallery: galleryReducer,
    exam:examReducer
  });
export default reducers;