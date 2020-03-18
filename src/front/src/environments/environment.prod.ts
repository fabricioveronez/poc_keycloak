import { KeycloakConfig } from 'keycloak-angular';

let keycloakConfig: KeycloakConfig = {
  url: 'http://id.veronez.net/auth',
  realm: 'poc',
  clientId: 'account',
  "credentials": {
    "secret": "your-client-secret"
  }
};

export const environment = {
  production: true,
  apiURL: 'http://api.veronez.net/api',
  keycloakConfig: keycloakConfig
};
