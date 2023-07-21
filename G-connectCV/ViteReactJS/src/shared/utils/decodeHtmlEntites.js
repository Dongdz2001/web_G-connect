import he from 'he';
const decodeHtmlEntites = (data)=>{
    if(data){
        try
        {
            let objectJson = JSON.parse(he.decode(JSON.stringify(data)));
            return objectJson;
        }
        catch(ex)
        {
            console.log('decodeHtmlEntites exception', ex)
            return data;
        }
        
    }else return {};
   
}
const decodeUnicode = (s) => {
    try {
        if(s)
            return he.decode(s);
        else
            return '';
    }
    catch {
        return s;
    }
}
const formatResourceLanguage = (t, lst) => {
    lst.map(item=>{
        if(item.Text.indexOf('=')>0) {
            item.Text = t(item.Text.split('=')[0], item.Text.split('=')[1]);
        }
    });
    return lst;
};
export { decodeHtmlEntites, decodeUnicode, formatResourceLanguage }