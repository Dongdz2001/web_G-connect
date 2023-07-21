import { createSlice } from '@reduxjs/toolkit'

export const listParamSlice = createSlice({
  name: 'listParam',
  initialState: [],
  reducers: {
    setParamState: (state, action) => {
      if(!state || !state)
        return state;
      if(!state.find(st => st && st.name == window.location.toString()))
        state.push({name:window.location.toString(), param:action.payload});
      state.map(st => {
        if(st && st.name == window.location.toString()) {
          st.param = action.payload;
        }
      });
      return state;
    },
  },
})

// Action creators are generated for each case reducer function
export const { setParamState } = listParamSlice.actions

export default listParamSlice.reducer