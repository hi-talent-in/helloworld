FROM openjdk:17 

EXPOSE 8080

ADD target/KuberDemo2.jar KuberDemo2.jar

ENTRYPOINT ["java", "-jar", "KuberDemo2.jar"]