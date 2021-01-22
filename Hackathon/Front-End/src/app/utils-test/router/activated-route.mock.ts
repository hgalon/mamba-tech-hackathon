import { Data, ActivatedRouteSnapshot, Params } from '@angular/router';
import { Subject } from 'rxjs';

export class ActivatedRouteMock {
  public static navigated = false;

  public dataSubject = new Subject<Data>();
  public data = this.dataSubject.asObservable();
  public snapshot: ActivatedRouteSnapshot;
  public queryParamsSubject = new Subject<Params>();
  public queryParams = this.queryParamsSubject.asObservable();
  public paramsSubject = new Subject<Params>();
  public params = this.paramsSubject.asObservable();

  public newParams(params: Params): void {
    this.paramsSubject.next(params);
  }

  public newQueryParams(queryParams: Params): void {
    this.queryParamsSubject.next(queryParams);
  }

  public newData(data: Data): void {
    this.dataSubject.next(data);
  }
}
