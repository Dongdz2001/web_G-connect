import { useSelector } from "react-redux";

function useCurrentUserDefault() {
    const userAllInfo = useSelector(state => state.oauth) || '';
    let value = {

        "Culture": userAllInfo.Culture,
        "CorporateId": userAllInfo.CorporateId,
        "UserId": userAllInfo.UserId,
        "TimeZoneValue": userAllInfo.TimeZoneValue,
        "EmailId": userAllInfo.EmailId,
        "UserRoles": userAllInfo.UserRoles,
        "AccessibleCategories": userAllInfo.AccessibleCategories,
        //"UserRoleId": userAllInfo.UserRoles[0]?.mnUserRoleId,// ==>mstrUserRoleName=Learner kiểm tra lại khi user login có nhiều role khác
        "WebAppFlag": userAllInfo.WebAppFlag
    }
    return value;
}
export { useCurrentUserDefault };