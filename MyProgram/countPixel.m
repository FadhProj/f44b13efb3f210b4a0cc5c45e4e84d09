function [ cPix ] = countPixel( img )
[ m n p ] = size(img);
cPix = zeros(1,256);
for i = 1 : m;
    for j = 1 : n;
        value = img(i,j);
        cPix(value+1) = cPix(value+1)+1;
    end
end
end