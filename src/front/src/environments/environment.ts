// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

import { KeycloakConfig } from 'keycloak-angular';

// Add here your keycloak setup infos
let keycloakConfig: KeycloakConfig = {
  url: 'http://192.168.0.12:8080/auth/',
  realm: 'poc',
  clientId: 'account',
  "credentials": {
    "secret": "04543da8-0d7c-4daf-9864-712ce8e6a3f9"
  }
};

export const environment = {
  production: false,
  apiURL: 'http://192.168.0.12:8282/api',
  keycloakConfig: keycloakConfig
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
