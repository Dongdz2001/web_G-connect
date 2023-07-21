import axios from "axios";
import { appSetting } from "shared/app-settings";

class BaseService {
  constructor(props = {}) {
    this.path = props ? props.url : "";
  }

  create(obj, action) {
    return axios.post(this.path + (action ?? "/create") + "", obj);
  }
  getById(id, action) {
    return axios.get(this.path + (action ?? "/") + "" + id);
  }
  update(id, obj, action) {
    return axios.put(this.path + (action ?? "/") + "" + id, obj);
  }
  delete(id, action) {
    return axios.delete(this.path + (action ?? "/") + "" + id);
  }
  deletes(ids) {
    return axios.post(this.path + (action ?? "/deletes"), ids);
  }
  filterPage(advanceSearch, action) {
    advanceSearch.search = advanceSearch.keySearch;
    advanceSearch.page_size = advanceSearch.items_per_page;
    advanceSearch.page = advanceSearch.current_page;
    advanceSearch.sort =
      '{"' +
      advanceSearch.sort_by +
      '": ' +
      (advanceSearch.descending ? 0 : 1) +
      "}";
    advanceSearch.page = advanceSearch.current_page;
    advanceSearch.filter = JSON.stringify(advanceSearch.filter);
    advanceSearch.sortField = null;
    advanceSearch.sortOrder = null;
    advanceSearch.rows = null;
    advanceSearch.refresh = null;
    advanceSearch.keySearch = null;
    advanceSearch.key_search = null;
    advanceSearch.items_per_page = null;
    advanceSearch.current_page = null;
    advanceSearch.sort_by = null;
    advanceSearch.descending = null;
    advanceSearch.multiSortMeta = null;
    let params = Object.keys(advanceSearch)
      .map((key) => (advanceSearch[key] ? `${key}=${advanceSearch[key]}` : ""))
      .join("&");
    //if(params.indexOf('&search=') < 0) params += '&search=';
    //if(params.indexOf('&descending=') < 0) params += '&descending=true';
    let url =
      this.path +
      (action ?? "/") +
      "?" +
      params
        .substring(1)
        .replace(/&&/g, "&")
        .replace(/&&/g, "&")
        .replace(/&&/g, "&")
        .replace(/&&/g, "&")
        .replace(/&&/g, "&");
    return axios.get(url.replace("?&", "?"));
  }
  getAll(action) {
    return axios.get(this.path + (action ?? "/all"));
  }
  getAllRef(path_api) {
    return axios.get(appSetting.PATH_APILMS_V2 + path_api);
  }

  getMany(props, url) {
    const { page, page_size, sort, filter, search } = props;
    const params = Object.assign(
      {},
      {
        page: page,
        page_size: page_size,
        sort: JSON.stringify(sort),
        filter: JSON.stringify(filter),
        search: search,
      },
      filter
    );
    if (url) {
      return http.get(url, { params: params });
    }
    return http.get(`${this.url}`, { params: params });
  }
}
var baseService = new BaseService();
export { BaseService, baseService };