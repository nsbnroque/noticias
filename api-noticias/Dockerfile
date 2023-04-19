FROM maven AS build
WORKDIR /home/app
COPY src  /home/app/src
COPY pom.xml /home/app/
RUN mvn clean package -Dspring.config.name=application-prod

FROM openjdk
COPY --from=build home/app/target/*.jar /app/app.jar
EXPOSE 8080
ENTRYPOINT ["java", "-jar", "/app/app.jar"]

