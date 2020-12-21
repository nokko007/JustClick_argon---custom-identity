setInterval('weeklysale()', 60 * 1000);
setInterval('dailysalebytsr()', 60 * 1000);
setInterval('agentmonitoring()', 60 * 1000);
setInterval('mtdperformance()', 60 * 1000);
setInterval('mtdperformancerenew()', 60 * 1000);




        $(document).ready(function () {
         weeklysale();
         dailysalebytsr();
         agentmonitoring();
         mtdperformance();
         mtdperformancerenew();


        });
