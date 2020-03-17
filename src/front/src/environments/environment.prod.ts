import { KeycloakConfig } from 'keycloak-angular';

let keycloakConfig: KeycloakConfig = {
  url: 'http://192.168.0.12:8080/auth',
  realm: 'poc',
  clientId: 'account',
  "credentials": {
    "secret": "your-client-secret"
  }
};

export const environment = {
  production: true,
  apiURL: 'http://192.168.0.12:8282/api',
  keycloakConfig: keycloakConfig
};
