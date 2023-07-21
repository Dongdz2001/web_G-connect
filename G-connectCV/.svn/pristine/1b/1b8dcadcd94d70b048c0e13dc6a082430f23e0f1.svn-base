import axios from 'axios'
import { BaseService } from 'services/BaseService';
import { appSetting } from 'shared/app-settings';

let path = appSetting.PATH_APILMS_V2 + '/link-qtht_chuc_vu'
class qtht_chuc_vuBaseService extends BaseService {
    constructor(props) {
        const _props = Object.assign({}, { url: appSetting.PATH_APILMS_V2 + '/link-qtht_chuc_vu' }, props);
        super(_props);
    }

}
const qtht_chuc_vuService = new qtht_chuc_vuBaseService();
export { qtht_chuc_vuService };
