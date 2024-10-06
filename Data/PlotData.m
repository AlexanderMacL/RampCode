% Plots for data for GEF project
close all
clear all
fls = dir('**/*.txt');

[A,B,C] = deal([]);

for i = 1:length(fls); A = [A;readlines([fls(i).folder '\' fls(i).name])]; end
for i = 1:length(A)
    a = split(A(i),',');
    if (length(a) == 6)
        b.timestamp = datetime(a{1}(2:end));
        b.track = str2double(a{2}(2:end));
        b.material = str2double(a{3}(2:end));
        b.width = str2double(a{4}(2:end));
        b.combo = str2double(a{5}(2:end));
        b.time = str2double(a{6})/1000;
    end
    if (b.time<10); B = [B b]; end % finishers
    if (b.time>=10); C = [C b]; end % dnf
end

% histogram of number of runs per unit datetime for each day
alpha = 0.8;
figure()
subplot(1,2,1);
% saturday
ts = vertcat(B.timestamp);
starttime = datetime('17/06/2023 10:00');
endtime = datetime('17/06/2023 18:30');
histogram(ts(ts<endtime & ts>starttime),starttime:duration('00:15:00'):endtime, 'Facealpha', alpha, 'FaceColor', [255 0 127]./255, 'DisplayName',['Finishers (' num2str(length(ts(ts<endtime & ts>starttime))) ' runs)']);
hold on
tsdnf = vertcat(C.timestamp);
histogram(tsdnf(tsdnf<endtime & tsdnf>starttime),starttime:duration('00:15:00'):endtime, 'Facealpha', alpha, 'FaceColor', [255, 153, 204]./255, 'DisplayName',['Did Not Finish (' num2str(length(tsdnf(tsdnf<endtime & tsdnf>starttime))) ' runs)']);
title('Saturday');
xticks(starttime:duration('01:00:00'):endtime);
box off
grid on;
legend('Location','nw');
subplot(1,2,2);
starttime = datetime('18/06/2023 10:00');
endtime = datetime('18/06/2023 18:30');
histogram(ts(ts<endtime & ts>starttime),starttime:duration('00:15:00'):endtime, 'Facealpha', alpha,  'FaceColor', [127 0 255]./255, 'DisplayName',['Finishers (' num2str(length(ts(ts<endtime & ts>starttime))) ' runs)']);
hold on
tsdnf = vertcat(C.timestamp);
histogram(tsdnf(tsdnf<endtime & tsdnf>starttime),starttime:duration('00:15:00'):endtime, 'Facealpha', alpha, 'FaceColor', [204, 153, 255]./255, 'DisplayName',['Did Not Finish (' num2str(length(tsdnf(tsdnf<endtime & tsdnf>starttime))) ' runs)']);
title('Sunday');
xticks(starttime:duration('01:00:00'):endtime);
box off
grid on;
legend('Location','nw');
set(gcf,'Position',[300,200,1200,400])
% saveas(gcf,'Daily.png');


% histogram by material against datetime
figure()
materials = {'Plastic','Wood','Felt','Combo'};
colours = [255 0 0; 255 150 0; 0 204 0; 0 0 255; 153 0 0; 153 100 0; 0 100 0; 0 0 120]./255;
for j = 1:4
    subplot(4,2,(j-1)*2+1);
    % saturday
    if (j<4)
        mts = ts(vertcat(B.material)==j-1 & vertcat(B.combo)==0);
    else
        mts = ts(vertcat(B.combo)==1);
    end
    starttime = datetime('17/06/2023 10:00');
    endtime = datetime('17/06/2023 18:30');
    histogram(mts(mts<endtime & mts>starttime),starttime:duration('00:15:00'):endtime, 'FaceColor', colours(j,:), 'DisplayName', [materials{j} ' (' num2str(length(mts(mts<endtime & mts>starttime))) ' runs)']);
    if (j==1); title('Saturday'); end
    xticks(starttime:duration('01:00:00'):endtime);
    ylim([0,20]);
    legend('Location','nw');
    box off
    grid on;
    subplot(4,2,(j-1)*2+2);
    starttime = datetime('18/06/2023 10:00');
    endtime = datetime('18/06/2023 18:30');
    histogram(mts(mts<endtime & mts>starttime),starttime:duration('00:15:00'):endtime, 'FaceColor', colours(j,:), 'DisplayName', [materials{j} ' (' num2str(length(mts(mts<endtime & mts>starttime))) ' runs)']);
    if (j==1); title('Sunday'); end
    xticks(starttime:duration('01:00:00'):endtime);
    ylim([0,20]);
    legend('Location','nw');
    box off
    grid on;
end
set(gcf,'Position',[300,20,1200,1100])
% saveas(gcf,'MaterialDateTime.png');

% histogram by material against time
figure()
for j=1:4
    subplot(2,2,j)
    t = vertcat(B.time);
    if (j<4)
        tm1 = t(vertcat(B.material)==j-1 & vertcat(B.combo)==0 & vertcat(B.track)==1);
        tm2 = t(vertcat(B.material)==j-1 & vertcat(B.combo)==0 & vertcat(B.track)==2);
    else
        tm1 = t(vertcat(B.combo)==1 & vertcat(B.track)==1);
        tm2 = t(vertcat(B.combo)==1 & vertcat(B.track)==2);
    end
    histogram(tm1,0.9:0.01:1.4,'FaceColor', colours(j+4,:),'FaceAlpha',0.7,'DisplayName',['Track 1 (' num2str(length(tm1)) ' runs)'])
    title(materials{j})
    xticks(0.8:0.1:1.4)
    xlabel('Time [s]');
    ylabel('Number of runs');
    ylim([0,31])    
    hold on
    histogram(tm2,0.9:0.01:1.4,'FaceColor', colours(j,:),'FaceAlpha',0.7,'DisplayName',['Track 2 (' num2str(length(tm2)) ' runs)']);
    legend();
    box off;
    grid on;
end
set(gcf,'Position',[350,-20,1200,800])
% saveas(gcf,'MaterialTime.png');

% histogram by material and width against time
figure()
widths = {'Narrow','Wide'};
for j=1:3
    subplot(1,3,j)
    t = vertcat(B.time);
    tm1 = t(vertcat(B.material)==j-1 & vertcat(B.combo)==0 & vertcat(B.width)==0);
    tm2 = t(vertcat(B.material)==j-1 & vertcat(B.combo)==0 & vertcat(B.width)==1);
    histogram(tm2,0.9:0.01:1.4,'FaceColor', colours(3,:),'FaceAlpha',0.7,'DisplayName',['Wide (' num2str(length(tm2)) ' runs)']);
    hold on
    histogram(tm1,0.9:0.01:1.4,'FaceColor', colours(2,:),'FaceAlpha',0.7,'DisplayName',['Narrow (' num2str(length(tm1)) ' runs)']);
    title(materials{j})
    xticks(0.8:0.1:1.4)
    xlabel('Time [s]');
    ylabel('Number of runs');
    ylim([0,33])
    
    legend();
    box off;
    grid on;
end
set(gcf,'Position',[350,60,1500,350])
% saveas(gcf,'MaterialWidthTime.png');

% bar graph of DNFs by material
figure()
subplot(1,2,1)
materials = {'Plastic','Wood','Felt','Rubber','Combo'};
Cm = [sum(vertcat(B.material)==0 & vertcat(B.combo)==0), ...
    sum(vertcat(B.material)==1 & vertcat(B.combo)==0), ...
    sum(vertcat(B.material)==2 & vertcat(B.combo)==0), ...
    sum(vertcat(B.material)==3 & vertcat(B.combo)==0), ...
    sum(vertcat(B.combo) == 1)];
for i=1:5; Xm{i} = [materials{i} ' ' num2str(Cm(i))]; end
X = categorical(Xm);
X = reordercats(X,Xm);
b = bar(X,Cm);
b.FaceColor = 'flat';
b.FaceAlpha = 0.7;
title('Finished Under 10 s');
grid on;
box off;
b.CData = colours([1:4,8],:);
ylim([0,300])

subplot(1,2,2)
Cm = [sum(vertcat(C.material)==0 & vertcat(C.combo)==0), ...
    sum(vertcat(C.material)==1 & vertcat(C.combo)==0), ...
    sum(vertcat(C.material)==2 & vertcat(C.combo)==0), ...
    sum(vertcat(C.material)==3 & vertcat(C.combo)==0), ...
    sum(vertcat(C.combo) == 1)];
for i=1:5; Xm{i} = [materials{i} ' ' num2str(Cm(i))]; end
X = categorical(Xm);
X = reordercats(X,Xm);
b = bar(X,Cm);
b.FaceColor = 'flat';
b.FaceAlpha = 0.7;
title('Did Not Finish');
b.CData = colours([1:4,8],:);
grid on;
box off;
ylim([0,300])

set(gcf,'Position',[300,200,1200,400])
% saveas(gcf,'Bars.png');

% histogram of dnfs by timestamp and material
alpha = 0.7;
figure()
subplot(1,2,1);
% saturday
starttime = datetime('17/06/2023 10:00');
endtime = datetime('17/06/2023 18:30');
cc = colours([1:4, 8],:);
tsdnf = vertcat(C.timestamp);
for j = 1:5
    if (j<5)
        mdnf = tsdnf(tsdnf<endtime & tsdnf>starttime & vertcat(C.material)==j-1 & vertcat(C.combo)==0);
    else
        mdnf = tsdnf(tsdnf<endtime & tsdnf>starttime & vertcat(C.combo)==1);
    end
    if (isempty(mdnf)); continue; end
    histogram(mdnf,starttime:duration('00:15:00'):endtime, 'Facealpha', alpha, 'FaceColor', cc(j,:), 'DisplayName',[materials{j} ' (' num2str(length(mdnf)) ' runs)']);
    hold on
end
title('Saturday');
xticks(starttime:duration('01:00:00'):endtime);
box off
grid on;
l = legend('Location','nw');
title(l,'Did Not Finish');
l.BoxFace.ColorType='truecoloralpha';
l.BoxFace.ColorData=uint8(255*[1 1 1 0.75]');
ylim([0,10]);
subplot(1,2,2);
starttime = datetime('18/06/2023 10:00');
endtime = datetime('18/06/2023 18:30');
for j = 1:5
    if (j<5)
        mdnf = tsdnf(tsdnf<endtime & tsdnf>starttime & vertcat(C.material)==j-1 & vertcat(C.combo)==0);
    else
        mdnf = tsdnf(tsdnf<endtime & tsdnf>starttime & vertcat(C.combo)==1);
    end
    histogram(mdnf,starttime:duration('00:15:00'):endtime, 'Facealpha', alpha, 'FaceColor', cc(j,:), 'DisplayName',[materials{j} ' (' num2str(length(mdnf)) ' runs)']);
    hold on
end
ylim([0,10]);
title('Sunday');
xticks(starttime:duration('01:00:00'):endtime);
box off
grid on;
ll = legend('Location','nw');
title(ll,'Did Not Finish');
ll.BoxFace.ColorType='truecoloralpha';
ll.BoxFace.ColorData=uint8(255*[1 1 1 0.75]');
set(gcf,'Position',[300,200,1200,400])
% saveas(gcf,'DailyDNFs.png');

% scatter plot time by material vs timestamp
figure()
markers = {'o','>','^','p','s'};
markersize = 20;
subplot(1,2,1);
% saturday
starttime = datetime('17/06/2023 10:00');
endtime = datetime('17/06/2023 18:30');
cc = colours([1:4, 8],:);
ts = vertcat(B.timestamp);
t = vertcat(B.time);
for j = 1:5
    if (j<5)
        m = ts(ts<endtime & ts>starttime & vertcat(B.material)==j-1 & vertcat(B.combo)==0);
        mt = t(ts<endtime & ts>starttime & vertcat(B.material)==j-1 & vertcat(B.combo)==0);
    else
        m = ts(ts<endtime & ts>starttime & vertcat(B.combo)==1);
        mt = t(ts<endtime & ts>starttime & vertcat(B.combo)==1);
    end
    if (isempty(m)); continue; end
    scatter(m,mt,markersize,markers{j},'MarkerEdgeColor',cc(j,:),'MarkerFaceColor', cc(j,:), 'DisplayName',[materials{j} ' (' num2str(length(m)) ' runs)']);
    hold on
end
title('Saturday');
xticks(starttime:duration('01:00:00'):endtime);
xlim([starttime,endtime]);
box off
grid on;
l = legend('Location','nw');
title(l,'Finished Under 10 s');
l.BoxFace.ColorType='truecoloralpha';
l.BoxFace.ColorData=uint8(255*[1 1 1 0.75]');
ylim([0,10]);
subplot(1,2,2);
starttime = datetime('18/06/2023 10:00');
endtime = datetime('18/06/2023 18:30');
for j = 1:5
    if (j<5)
        m = ts(ts<endtime & ts>starttime & vertcat(B.material)==j-1 & vertcat(B.combo)==0);
        mt = t(ts<endtime & ts>starttime & vertcat(B.material)==j-1 & vertcat(B.combo)==0);
    else
        m = ts(ts<endtime & ts>starttime & vertcat(B.combo)==1);
        mt = t(ts<endtime & ts>starttime & vertcat(B.combo)==1);
    end
    if (isempty(m)); continue; end
    scatter(m,mt,markersize,markers{j},'MarkerEdgeColor',cc(j,:),'MarkerFaceColor', cc(j,:), 'DisplayName',[materials{j} ' (' num2str(length(m)) ' runs)']);
    hold on
end
ylim([0,10]);
title('Sunday');
xticks(starttime:duration('01:00:00'):endtime)
xlim([starttime,endtime]);
box off
grid on;
ll = legend('Location','nw');
title(ll,'Finished Under 10 s');
ll.BoxFace.ColorType='truecoloralpha';
ll.BoxFace.ColorData=uint8(255*[1 1 1 0.75]');
set(gcf,'Position',[300,200,1200,400])
saveas(gcf,'Scatter10.png');

% scatter plot time by track vs timestamp
figure()
markers = {'o','s'};
markersize = 20;
subplot(1,2,1);
% saturday
starttime = datetime('17/06/2023 10:00');
endtime = datetime('17/06/2023 18:30');
cc = [[1,1,1].*0.5;[1,1,1].*0];
ts = vertcat(B.timestamp);
t = vertcat(B.time);
for j = 1:2
    m = ts(ts<endtime & ts>starttime & vertcat(B.track)==j);
    mt = t(ts<endtime & ts>starttime & vertcat(B.track)==j);
    if (isempty(m)); continue; end
    scatter(m,mt,markersize,markers{j},'MarkerEdgeColor',cc(j,:),'MarkerFaceColor', cc(j,:), 'DisplayName',['Track ' num2str(j) ' (' num2str(length(m)) ' runs)']);
    hold on
end
title('Saturday');
xticks(starttime:duration('01:00:00'):endtime);
xlim([starttime,endtime]);
box off
grid on;
l = legend('Location','nw');
title(l,'Finished Under 2 s');
l.BoxFace.ColorType='truecoloralpha';
l.BoxFace.ColorData=uint8(255*[1 1 1 0.75]');
ylim([0,2]);
subplot(1,2,2);
starttime = datetime('18/06/2023 10:00');
endtime = datetime('18/06/2023 18:30');
for j = 1:2
    m = ts(ts<endtime & ts>starttime & vertcat(B.track)==j);
    mt = t(ts<endtime & ts>starttime & vertcat(B.track)==j);
    if (isempty(m)); continue; end
    scatter(m,mt,markersize,markers{j},'MarkerEdgeColor',cc(j,:),'MarkerFaceColor', cc(j,:), 'DisplayName',['Track ' num2str(j) ' (' num2str(length(m)) ' runs)']);
    hold on
end
ylim([0,2]);
title('Sunday');
xticks(starttime:duration('01:00:00'):endtime)
xlim([starttime,endtime]);
box off
grid on;
ll = legend('Location','nw');
title(ll,'Finished Under 2 s');
ll.BoxFace.ColorType='truecoloralpha';
ll.BoxFace.ColorData=uint8(255*[1 1 1 0.75]');
set(gcf,'Position',[300,200,1200,400])
saveas(gcf,'ScatterTrack2.png');
