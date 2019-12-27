import { KeycloakConfig } from 'keycloak-angular';

let keycloakConfig: KeycloakConfig = {
  url: 'http://KEYCLOAK-IP:8088/auth',
  realm: 'your-realm-name',
  clientId: 'your-client-id',
  "credentials": {
    "secret": "your-client-secret"
  }
};

export const environment = {
  production: true,
  apiURL: 'http://localhost:8181/api',
  keycloakConfig: keycloakConfig
};
