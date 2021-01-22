import { Event, NavigationExtras, UrlTree } from '@angular/router';
import { Subject } from 'rxjs';

export class RouterMock {
  public static navigated = false;
  public eventSubject = new Subject<Event>();
  public events = this.eventSubject.asObservable();

  public newEvent(event: Event) {
    this.eventSubject.next(event);
  }

  public navigate(commands: any[], extras?: NavigationExtras): Promise<boolean> {
    return new Promise<boolean>((resolve, reject) => {
      RouterMock.navigated = true;
      resolve(true);
    });
  }

  public navigateByUrl(url: string, extras?: NavigationExtras): Promise<boolean> {
    return new Promise<boolean>((resolve, reject) => {
      RouterMock.navigated = true;
      resolve(true);
    });
  }

  public isActive(url: string, tree: boolean): boolean {
    return tree;
  }

  public createUrlTree(commands: any[], navigationExtras?: NavigationExtras): UrlTree {
    return {} as UrlTree;
  }
}
