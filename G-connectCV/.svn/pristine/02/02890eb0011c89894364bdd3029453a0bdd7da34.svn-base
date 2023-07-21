import { createSlice } from '@reduxjs/toolkit'

export const perFormExam = createSlice({
  name: 'exam',
  initialState: {
    dataResumeassessment:{},
    datamrqquestion:{},
    datafibquestion:{},
    datamcqquestion:{},
    datatfquestion:{},
    datamfquestion:{},
    dataosquestion:{},
    QuestionIdList:[],
    QuestionTypeList:[],
    SelectedQuestion:{},
    visibleDialog:false
}
  ,
  reducers: {
    updateResumeassessment: (state, action)=> {
        state.dataResumeassessment=action.payload
    },
    // câu hỏi đúng sai 
    //type=1
    updatetfquestion: (state, action)=> {
        state.datatfquestion=action.payload
    },
    //câu hỏi điền vào chỗ trống
    //type=2
    updatefibquestion: (state, action)=> {
        state.datafibquestion=action.payload
    },
    //câu hỏi trắc nghiệm
    //type=3
    updatemcqquestion: (state, action)=> {
        state.datamcqquestion=action.payload
    },
    //Nhiều câu trả lời
    //Type=4
    updatemrqquestion: (state, action)=> {
        state.datamrqquestion=action.payload
    },
    //câu hỏi nối từ
    //Type=5
    updatemfquestion: (state, action)=> {
        state.datamfquestion=action.payload
    },
    //câu hỏi nối từ
    //Type=5
    updateosquestion: (state, action)=> {
        state.dataosquestion=action.payload
    },
    setQuestionIdList: (state, action)=> {
        state.QuestionIdList=action.payload
    },
    setQuestionTypeList: (state, action)=> {
        state.QuestionTypeList=action.payload
    },
    setvisibleDialog: (state, action)=> {
        state.visibleDialog=action.payload
    },
  },
})

// Action creators are generated for each case reducer function
export const {setvisibleDialog,setQuestionIdList,updateResumeassessment,updatemrqquestion,updatefibquestion,updatemcqquestion,updatetfquestion,updatemfquestion,updateosquestion } = perFormExam.actions

export default perFormExam.reducer