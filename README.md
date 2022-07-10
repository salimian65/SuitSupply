# OmsRlcMessageListener APP

This application is responsible to handle just Rlc message which is published from Rlc to keep update OMS instrument repository also this app handle three messages InstrumentAdded, InstrumentStateChanged, InstrumentGroupStateChanged 
## Architecture

![Architecture image](readme/Architecture.JPG)

# DevOps

## Dockerfile
- [Dockerfile](src/OrderManagementService.RlcMessageListener/Dockerfile)
## Testing

## Load Test

## Profiling

## Code quality


## Healthcheck

http://servicename/healthz
* http://servicename/healthz/live
* http://servicename/healthz/ready
* http://servicename/healthz/version

## Monitoring Metrics

curl -XGET http://servicename/metrics


## Configuration Files

There are two configuration files. The first one is used in development profile, and the second is for production environment.

- [Development Config](src/OrderManagementService.RlcMessageListener/appsettings.json)
- [Production Config](src/OrderManagementService.RlcMessageListener/appsettings.json)

## Tag
This service will push with tag "release" in git.

## Scalability

this app should be single instance