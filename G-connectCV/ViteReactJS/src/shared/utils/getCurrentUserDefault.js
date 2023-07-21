const getCurrentUserDefault = () => {
    let root = localStorage.getItem("persist:root");
    if(!root)
        return {};
    let oauthJSON = JSON.parse(root);
    let userAllInfo = JSON.parse(oauthJSON.oauth);
    let UserRoleId = 3;
    let value = userAllInfo.user_info;
    return value;
}

export { getCurrentUserDefault };